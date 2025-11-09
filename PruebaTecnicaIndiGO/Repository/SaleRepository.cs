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
    internal class SaleRepository
    {
        private readonly string _connectionString;

        public SaleRepository()
        {
            _connectionString = Connection.Instance.GetConnectionString();
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            string query = @"SELECT id, code, name, cost, stock, picture 
                            FROM oastudillo.Product 
                            ORDER BY name";

            var products = new List<Product>();

            try
            {
                using var conn = new SqlConnection(_connectionString);
                using var cmd = new SqlCommand(query, conn);

                await conn.OpenAsync();
                using var reader = await cmd.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    products.Add(new Product
                    {
                        Id = reader.GetInt32(0),
                        Code = reader.GetString(1),
                        Name = reader.GetString(2),
                        Cost = reader.GetDecimal(3),
                        Stock = reader.GetInt32(4),
                        Picture = reader.IsDBNull(5) ? "" : reader.GetString(5)
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener productos: {ex.Message}");
            }

            return products;
        }

        public async Task<bool> SaveSaleAsync(Sale sale)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();
            using var transaction = conn.BeginTransaction();

            try
            {
                string saleQuery = @"INSERT INTO oastudillo.Sale (date, total) 
                                    VALUES (@date, @total);
                                    SELECT SCOPE_IDENTITY();";

                int saleId;
                using (var cmd = new SqlCommand(saleQuery, conn, transaction))
                {
                    cmd.Parameters.AddWithValue("@date", sale.Date);
                    cmd.Parameters.AddWithValue("@total", sale.Total);

                    var result = await cmd.ExecuteScalarAsync();
                    saleId = Convert.ToInt32(result);
                }
                string itemQuery = @"INSERT INTO oastudillo.SaleItems (saleId, productId, quantity, totalValue) 
                                    VALUES (@saleId, @productId, @quantity, @totalValue)";

                foreach (var item in sale.Items)
                {
                    using var cmd = new SqlCommand(itemQuery, conn, transaction);
                    cmd.Parameters.AddWithValue("@saleId", saleId);
                    cmd.Parameters.AddWithValue("@productId", item.ProductId);
                    cmd.Parameters.AddWithValue("@quantity", item.Quantity);
                    cmd.Parameters.AddWithValue("@totalValue", item.TotalValue);

                    await cmd.ExecuteNonQueryAsync();
                }

                string updateStockQuery = @"UPDATE oastudillo.Product 
                                          SET stock = stock - @quantity 
                                          WHERE id = @productId AND stock >= @quantity";

                foreach (var item in sale.Items)
                {
                    using var cmd = new SqlCommand(updateStockQuery, conn, transaction);
                    cmd.Parameters.AddWithValue("@quantity", item.Quantity);
                    cmd.Parameters.AddWithValue("@productId", item.ProductId);

                    int affected = await cmd.ExecuteNonQueryAsync();
                    if (affected == 0)
                    {
                        throw new Exception($"El stock insuficiente para el producto ID: {item.ProductId}");
                    }
                }

                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Console.WriteLine($"Error al guardar venta: {ex.Message}");
                return false;
            }
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            string query = @"SELECT id, code, name, cost, stock, picture 
                            FROM oastudillo.Product 
                            WHERE id = @id";

            try
            {
                using var conn = new SqlConnection(_connectionString);
                using var cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@id", id);

                await conn.OpenAsync();
                using var reader = await cmd.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    return new Product
                    {
                        Id = reader.GetInt32(0),
                        Code = reader.GetString(1),
                        Name = reader.GetString(2),
                        Cost = reader.GetDecimal(3),
                        Stock = reader.GetInt32(4),
                        Picture = reader.IsDBNull(5) ? "" : reader.GetString(5)
                    };
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al buscar producto: {ex.Message}");
                return null;
            }
        }
    }
}