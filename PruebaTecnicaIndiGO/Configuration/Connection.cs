using System;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;

namespace PruebaTecnicaIndiGO.Configuration
{
    /// <summary>
    /// Uso singleton conexion
    /// </summary>
    public sealed class Connection
    {
        private static Connection? _instance;
        private static readonly object _lock = new object();
        private readonly string _connectionString;

        private Connection()
        {
            _connectionString = "Server=ssindigodev.database.windows.net;Database=prueba_indigo;User ID=DbaIndigo;Password=%FY!4%k4p;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        }

        public static Connection Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new Connection();
                        }
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        /// Obtiene una nueva conexionn SQL
        /// </summary>
        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        /// <summary>
        /// Obtiene la conexion
        /// </summary>
        public string GetConnectionString()
        {
            return _connectionString;
        }
    }
}

