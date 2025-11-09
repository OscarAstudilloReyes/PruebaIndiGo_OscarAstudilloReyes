using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaIndiGO.Model
{
    public class SaleReportDto
    {
        public int SaleId { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public int ProductCount { get; set; }
        public int TotalQuantity { get; set; }
    }
}
