using PruebaTecnicaIndiGO.Model;
using PruebaTecnicaIndiGO.Repository;
using PruebaTecnicaIndiGO.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaIndiGO.Presenter
{
    internal class SalePresenter
    {
        private readonly ISaleView _view;
        private readonly SaleRepository _repository;
        private readonly List<SaleItems> _saleItems;

        public SalePresenter(ISaleView view)
        {
            _view = view;
            _repository = new SaleRepository();
            _saleItems = new List<SaleItems>();
        }

        public async Task LoadProductsAsync()
        {
            try
            {
                var products = await _repository.GetAllProductsAsync();
                _view.LoadProductsComboBox(products);
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"Error al cargar productos: {ex.Message}");
            }
        }

        public async void AddItemToGridAsync()
        {
            try
            {
                // Validaciones
                if (_view.SelectedProductId <= 0)
                {
                    _view.ShowMessage("Debe seleccionar un producto");
                    return;
                }

                if (_view.Quantity <= 0)
                {
                    _view.ShowMessage("La cantidad debe ser mayor a 0");
                    return;
                }

                // Obtener información del producto
                var product = await _repository.GetProductByIdAsync(_view.SelectedProductId);
                if (product == null)
                {
                    _view.ShowMessage("Producto no encontrado");
                    return;
                }

                // Verificar stock disponible
                var totalQuantityInGrid = _saleItems.Where(x => x.ProductId == product.Id).Sum(x => x.Quantity);
                var availableStock = product.Stock - totalQuantityInGrid;

                if (_view.Quantity > availableStock)
                {
                    _view.ShowMessage($"Stock insuficiente. Disponible: {availableStock}");
                    return;
                }

                // Calcular total del item
                decimal totalValue = _view.Quantity * product.Cost;

                // Verificar si ya existe el producto en la rejilla
                var existingItem = _saleItems.FirstOrDefault(x => x.ProductId == product.Id);
                if (existingItem != null)
                {
                    // Actualizar cantidad y total si ya existe
                    existingItem.Quantity += _view.Quantity;
                    existingItem.TotalValue += totalValue;
                }
                else
                {
                    // Agregar nuevo item
                    var saleItem = new SaleItems
                    {
                        ProductId = product.Id,
                        Quantity = _view.Quantity,
                        TotalValue = totalValue,
                        Product = product
                    };
                    _saleItems.Add(saleItem);
                }

                // Actualizar la rejilla y totales
                _view.LoadSaleItemsGrid(_saleItems);
                _view.ClearItemFields();
                UpdateTotals(); // Llamar después de limpiar para que muestre el total de la venta
                
                _view.ShowMessage("Item agregado correctamente");
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"Error al agregar item: {ex.Message}");
            }
        }

        public async Task SaveSaleAsync()
        {
            try
            {
                if (!_saleItems.Any())
                {
                    _view.ShowMessage("Debe agregar al menos un item a la venta");
                    return;
                }

                // Crear la venta
                var sale = new Sale
                {
                    Date = _view.SaleDateTime,
                    Total = _view.TotalValue,
                    Items = _saleItems
                };

                bool success = await _repository.SaveSaleAsync(sale);
                
                if (success)
                {
                    _view.ShowMessage("Venta guardada correctamente");
                    ClearSale();
                }
                else
                {
                    _view.ShowMessage("Error al guardar la venta");
                }
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"Error al guardar venta: {ex.Message}");
            }
        }

        public void RemoveItemFromGrid(int index)
        {
            try
            {
                if (index >= 0 && index < _saleItems.Count)
                {
                    _saleItems.RemoveAt(index);
                    _view.LoadSaleItemsGrid(_saleItems);
                    UpdateTotals();
                    _view.ShowMessage("Item eliminado correctamente");
                }
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"Error al eliminar item: {ex.Message}");
            }
        }

        private void UpdateTotals()
        {
            decimal total = _saleItems.Sum(x => x.TotalValue);
            _view.UpdateTotalValue(total);
        }

        private void ClearSale()
        {
            _saleItems.Clear();
            _view.LoadSaleItemsGrid(_saleItems);
            _view.ClearAllFields();
            UpdateTotals();
        }

        public void CalculateItemTotal()
        {
            try
            {
                if (_view.SelectedProductId > 0 && _view.Quantity > 0)
                {
                    // Esta lógica se puede usar si quieres mostrar el total del item antes de agregarlo
                    // Por ahora no la implementaré, pero está disponible si la necesitas
                }
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"Error al calcular total: {ex.Message}");
            }
        }
    }
}