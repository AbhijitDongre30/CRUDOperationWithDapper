using CRUDOperationWithDapper.Models;

namespace CRUDOperationWithDapper.Interfaces
{
    public interface IEmployee
    {
        Task<List<Employee>> getEmployeeList();
        Task<List<Employee>> getEmployeeListWithfunc();
        Task<string> EmployeeInsert(Employee employee);
        Task<string> EmployeeUpdate(Employee employee);
        Task<string> EmployeeDelete(Employee employee);
        Task EmployeeInsertProc(Employee employee);
    }
}
