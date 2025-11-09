using PruebaTecnicaIndiGO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaIndiGO.Views
{
    public interface ISaleView
    {
        // Propiedades para leer datos del formulario
        int SelectedProductId { get; }
        int Quantity { get; }
        decimal TotalValue { get; }
        DateTime SaleDateTime { get; }

        // Métodos para mostrar información
        void ShowMessage(string message);

        // Métodos para manejar controles
        void LoadProductsComboBox(List<Product> products);
        void LoadSaleItemsGrid(List<SaleItems> saleItems);
        void UpdateTotalValue(decimal total);

        // Métodos para limpiar campos
        void ClearItemFields();
        void ClearAllFields();
    }
}
