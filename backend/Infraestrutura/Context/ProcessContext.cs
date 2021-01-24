using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace Infraestrutura.Context
{
    public sealed class ProcessContext : IProcessContext
    {
        private readonly IConfiguration _configuration;
        private IDbConnection _dbConnection;
        private bool _disposed = false;

        public ProcessContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Dispose()
        {
            if (_disposed)
                return;

            if (_dbConnection?.State == ConnectionState.Open)
            {
                _dbConnection.Close();
            }

            _disposed = true;
        }

        /// <summary>
        /// Retorna uma nova instância de conexão ou reutiliza a mesma caso já tenha aberto.
        /// </summary>
        public IDbConnection GetConnection()
        {
            if (_dbConnection is null)
            {
                _dbConnection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            }

            return _dbConnection;
        }
    }
}