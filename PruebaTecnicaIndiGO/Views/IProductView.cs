using PruebaTecnicaIndiGO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaIndiGO.Views
{
    public interface IProductView
    {
        string ProductCode { get; }
        string ProductName { get; }
        decimal ProductCost { get; }
        int ProductStock { get; }
        string ProductPicture { get; }

        void ShowMessage(string message);
        void LoadProduct(Product product);
        void LoadProductsGrid(List<Product> products);
    }
}
