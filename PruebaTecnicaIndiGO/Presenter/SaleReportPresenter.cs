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
    internal class SaleReportPresenter
    {
        private readonly ISaleReportView _view;
        private readonly SaleReportRepository _repository;

        public SaleReportPresenter(ISaleReportView view)
        {
            _view = view;
            _repository = new SaleReportRepository();
        }

        public async Task GenerateReportAsync()
        {
            try
            {
                _view.ClearReport();
                var salesReport = await _repository.GetSalesReportAsync(_view.StartDate, _view.EndDate);
                
                if (salesReport.Count == 0)
                {
                    _view.ShowMessage("No se encontraron ventas en el rango de fechas indicasdas");
                    return;
                }
                // carga datos en la vista
                _view.LoadSalesReport(salesReport);

            }
            catch (Exception ex)
            {
                _view.ShowMessage($"Error al generar el reporte: {ex.Message}");
            }
        }

        public async Task ShowSaleDetailsAsync(int saleId)
        {
            try
            {
                var saleDetails = await _repository.GetSaleDetailsAsync(saleId);
                
                if (saleDetails.Count == 0)
                {
                    _view.ShowMessage("No se encontraron detalles para esta venta");
                    return;
                }

                // Crear ventana de detalles (opcional)
                var detailsMessage = "Detalles de la venta:\n\n";
                foreach (var item in saleDetails)
                {
                    detailsMessage += $"• {item.Product.Name} - Cantidad: {item.Quantity} - Total: {item.TotalValue:C2}\n";
                }

                _view.ShowMessage(detailsMessage);
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"Error al obtener detalles de la venta: {ex.Message}");
            }
        }

    }
}
