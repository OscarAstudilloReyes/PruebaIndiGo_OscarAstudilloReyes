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
    internal class ProductRepository
    {

        private readonly string _connectionString;

        public ProductRepository()
        {
            _connectionString = Connection.Instance.GetConnectionString();
        }

        public async Task<bool> AddProductAsync(Product product)
        {
            string query = @"INSERT INTO oastudillo.Product (code, name, cost, stock, picture)
                             VALUES (@code, @name, @cost, @stock, @picture)";

            try
            {
                using var conn = new SqlConnection(_connectionString);
                using var cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@code", product.Code);
                cmd.Parameters.AddWithValue("@name", product.Name);
                cmd.Parameters.AddWithValue("@cost", product.Cost);
                cmd.Parameters.AddWithValue("@stock", product.Stock);
                cmd.Parameters.AddWithValue("@picture", (object?)product.Picture ?? DBNull.Value);

                await conn.OpenAsync();
                int result = await cmd.ExecuteNonQueryAsync();
                return result > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al adicionar producto: {ex.Message}");
                return false;
            }
        }

        public async Task<Product?> GetProductByNameAsync(string name)
        {
            string query = @"SELECT id, code, name, cost, stock, picture 
                            FROM oastudillo.Product 
                            WHERE name = @name";

            try
            {
                using var conn = new SqlConnection(_connectionString);
                using var cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@name", name);

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
                Console.WriteLine($"Error al buscar producto por nombre: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            string query = @"UPDATE oastudillo.Product 
                            SET code = @code, name = @name, cost = @cost, stock = @stock, picture = @picture
                            WHERE id = @id";

            try
            {
                using var conn = new SqlConnection(_connectionString);
                using var cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@id", product.Id);
                cmd.Parameters.AddWithValue("@code", product.Code);
                cmd.Parameters.AddWithValue("@name", product.Name);
                cmd.Parameters.AddWithValue("@cost", product.Cost);
                cmd.Parameters.AddWithValue("@stock", product.Stock);
                cmd.Parameters.AddWithValue("@picture", (object?)product.Picture ?? DBNull.Value);

                await conn.OpenAsync();
                int result = await cmd.ExecuteNonQueryAsync();
                return result > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar producto: {ex.Message}");
                return false;
            }
        }

        public async Task<Product?> GetProductByCodeAsync(string code)
        {
            string query = @"SELECT id, code, name, cost, stock, picture 
                            FROM oastudillo.Product 
                            WHERE code = @code";

            try
            {
                using var conn = new SqlConnection(_connectionString);
                using var cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@code", code);

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
                Console.WriteLine($"Error al buscar producto por código: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> DeleteProductByCodeAsync(string code)
        {
            string query = @" DELETE si
                FROM oastudillo.SaleItems si
                JOIN oastudillo.Product p ON si.productId = p.id
                WHERE p.code = @code
                DELETE FROM oastudillo.Product
                WHERE code = @code
                    ";
            try
            {
                using var conn = new SqlConnection(_connectionString);
                using var cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@code", code);

                await conn.OpenAsync();
                int result = await cmd.ExecuteNonQueryAsync();
                return result > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar producto: {ex.Message}");
                return false;
            }
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
    }
}
