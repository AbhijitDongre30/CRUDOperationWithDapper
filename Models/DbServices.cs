using CRUDOperationWithDapper.Interfaces;
using Dapper;
using System.Data;
using Npgsql;

namespace CRUDOperationWithDapper.Models
{
    public class DbServices : IDbServices,IDisposable
    {
        private readonly IDbConnection _connection;
        public DbServices(IConfiguration configuration) {

            _connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        

        public async Task<int> InsertUpdateDeleteInline<T>(string command, object param)
        {
            try
            {
                var result = (await _connection.ExecuteAsync(command, param));
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error:", ex);
            }
            finally
            {
                _connection.Close();
            }
        }

        public async Task<List<T>> SelectInline<T>(string command, object param)
        {
            try
            {
                List<T> result = (await _connection.QueryAsync<T>(command, param)).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error:",ex);
            }
            finally
            {
                _connection.Close();
            }
        }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}
