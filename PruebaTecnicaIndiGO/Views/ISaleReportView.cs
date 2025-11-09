using PruebaTecnicaIndiGO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaIndiGO.Views
{
    public interface ISaleReportView
    {
        DateTime StartDate { get; }
        DateTime EndDate { get; }
        void ShowMessage(string message);
        void LoadSalesReport(List<SaleReportDto> salesReport);
        void ClearReport();
    }
}
