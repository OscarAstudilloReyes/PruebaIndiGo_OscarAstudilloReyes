using Microsoft.Data.SqlClient;
using PruebaTecnicaIndiGO.Configuration;
using PruebaTecnicaIndiGO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaIndiGO.Repository
{
    internal class SaleReportRepository
    {
        private readonly string _connectionString;

        public SaleReportRepository()
        {
            _connectionString = Connection.Instance.GetConnectionString();
        }

        public async Task<List<SaleReportDto>> GetSalesReportAsync(DateTime startDate, DateTime endDate)
        {
            string query = @"
                SELECT 
                    s.id AS SaleId,
                    s.date AS Date,
                    s.total AS Total,
                    COUNT(si.productId) AS ProductCount,
                    SUM(si.quantity) AS TotalQuantity
                FROM oastudillo.Sale s
                LEFT JOIN oastudillo.SaleItems si ON s.id = si.saleId
                WHERE s.date >= @startDate AND s.date <= @endDate
                GROUP BY s.id, s.date, s.total
                ORDER BY s.date DESC";

            var reportData = new List<SaleReportDto>();

            try
            {
                using var conn = new SqlConnection(_connectionString);
                using var cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@startDate", startDate.Date);
                cmd.Parameters.AddWithValue("@endDate", endDate.Date.AddDays(1).AddTicks(-1)); 

                await conn.OpenAsync();
                using var reader = await cmd.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    reportData.Add(new SaleReportDto
                    {
                        SaleId = reader.GetInt32(0),
                        Date = reader.GetDateTime(1),
                        Total = reader.GetDecimal(2),
                        ProductCount = reader.IsDBNull(3) ? 0 : reader.GetInt32(3),
                        TotalQuantity = reader.IsDBNull(4) ? 0 : reader.GetInt32(4)
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener reporte de ventas: {ex.Message}");
            }

            return reportData;
        }

        public async Task<List<SaleItems>> GetSaleDetailsAsync(int saleId)
        {
            string query = @"
                SELECT 
                    si.id,
                    si.saleId,
                    si.productId,
                    si.quantity,
                    si.totalValue,
                    p.id,
                    p.code,
                    p.name,
                    p.cost,
                    p.stock,
                    p.picture
                FROM oastudillo.SaleItems si
                INNER JOIN oastudillo.Product p ON si.productId = p.id
                WHERE si.saleId = @saleId
                ORDER BY p.name";

            var saleItems = new List<SaleItems>();

            try
            {
                using var conn = new SqlConnection(_connectionString);
                using var cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@saleId", saleId);

                await conn.OpenAsync();
                using var reader = await cmd.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    var product = new Product
                    {
                        Id = reader.GetInt32(5),
                        Code = reader.GetString(6),
                        Name = reader.GetString(7),
                        Cost = reader.GetDecimal(8),
                        Stock = reader.GetInt32(9),
                        Picture = reader.IsDBNull(10) ? "" : reader.GetString(10)
                    };

                    saleItems.Add(new SaleItems
                    {
                        Id = reader.GetInt32(0),
                        SaleId = reader.GetInt32(1),
                        ProductId = reader.GetInt32(2),
                        Quantity = reader.GetInt32(3),
                        TotalValue = reader.GetDecimal(4),
                        Product = product
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener detalles de venta: {ex.Message}");
            }

            return saleItems;
        }
    }
}
