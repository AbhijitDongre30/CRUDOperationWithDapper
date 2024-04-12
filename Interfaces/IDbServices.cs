using Dapper;

namespace CRUDOperationWithDapper.Interfaces
{
    public interface IDbServices
    {
        Task<List<T>> SelectInline<T>(string command,object param);
        Task<int> InsertUpdateDeleteInline<T>(string command,object param);
        Task<List<T>> GetAllRecordsWithfunc<T>(string command,object param);
        Task<int> InsertUpdateDeleteProcedure<T>(string command, DynamicParameters param);
    }
}
