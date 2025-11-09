using Microsoft.Data.SqlClient;
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
    internal class ProductPresenter
    {
        private readonly IProductView _view;
        private readonly ProductRepository _repository;

        public ProductPresenter(IProductView view)
        {
            _view = view;
            _repository = new ProductRepository();
        }

        public async Task SaveProductAsync()
        {
            try
            {
                // Validar que no este vacio
                if (string.IsNullOrWhiteSpace(_view.ProductCode))
                {
                    _view.ShowMessage("El código del producto es obligatorio");
                    return;
                }

                if (string.IsNullOrWhiteSpace(_view.ProductName))
                {
                    _view.ShowMessage("El nombre del producto es obligatorio");
                    return;
                }

                // Consultar existencia
                var existingProduct = await _repository.GetProductByCodeAsync(_view.ProductCode);
                
                bool success;
                string message;

                if (existingProduct != null)
                {
                    // Si existe, actualizar el producto 
                    existingProduct.Code = _view.ProductCode;
                    existingProduct.Name = _view.ProductName;
                    existingProduct.Cost = _view.ProductCost;
                    existingProduct.Stock = _view.ProductStock;
                    existingProduct.Picture = _view.ProductPicture;

                    success = await _repository.UpdateProductAsync(existingProduct);
                    message = success ? "Producto actualizado correctamente" : "Error al actualizar el producto";
                }
                else
                {
                    // Si no existe, se crea
                    var newProduct = new Product
                    {
                        Id = 0,
                        Code = _view.ProductCode,
                        Name = _view.ProductName,
                        Cost = _view.ProductCost,
                        Stock = _view.ProductStock,
                        Picture = _view.ProductPicture
                    };

                    success = await _repository.AddProductAsync(newProduct);
                    message = success ? "Producto guardado correctamente" : "Error al guardar el producto";
                }

                _view.ShowMessage(message);
            }
            catch (Exception ex) 
            {
                _view.ShowMessage($"Error: {ex.Message}");
            }
        }

        public async Task SearchProductByNameAsync(string productName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(productName))
                {
                    _view.ShowMessage("Ingrese el nombre del producto a buscar");
                    return;
                }

                var product = await _repository.GetProductByNameAsync(productName);
                
                if (product != null)
                {
                    _view.LoadProduct(product);
                    _view.ShowMessage("Producto encontrado y cargado");
                }
                else
                {
                    _view.ShowMessage("Producto no encontrado");
                }
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"Error al buscar producto: {ex.Message}");
            }
        }

        public async Task SearchProductByCodeAsync(string productCode)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(productCode))
                {
                    _view.ShowMessage("Ingrese el codigo del producto a buscar");
                    return;
                }

                var product = await _repository.GetProductByCodeAsync(productCode);
                
                if (product != null)
                {
                    _view.LoadProduct(product);
                    _view.ShowMessage("Producto encontrado y cargado");
                }
                else
                {
                    _view.ShowMessage("Producto no encontrado");
                }
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"Error al buscar producto: {ex.Message}");
            }
        }

        public async Task DeleteProductAsync(string productCode)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(productCode))
                {
                    _view.ShowMessage("Ingrese el codigo del producto a eliminar");
                    return;
                }

                // Verificar si existe el producto antes de eliminar
                var existingProduct = await _repository.GetProductByCodeAsync(productCode);
                
                if (existingProduct == null)
                {
                    _view.ShowMessage("El producto no existe");
                    return;
                }

                bool success = await _repository.DeleteProductByCodeAsync(productCode);
                
                if (success)
                {
                    _view.ShowMessage("Producto eliminado correctamente");
                }
                else
                {
                    _view.ShowMessage("Error al eliminar el producto");
                }
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"Error al eliminar producto: {ex.Message}");
            }
        }

        public async Task LoadAllProductsAsync()
        {
            try
            {
                var products = await _repository.GetAllProductsAsync();
                _view.LoadProductsGrid(products);
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"Error al cargar productos: {ex.Message}");
            }
        }
    }
}




