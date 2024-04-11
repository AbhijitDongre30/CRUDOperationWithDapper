using CRUDOperationWithDapper.Models;

namespace CRUDOperationWithDapper.Interfaces
{
    public interface IEmployee
    {
        Task<List<Employee>> getEmployeeList();

        Task<string> EmployeeInsert(Employee employee);
        Task<string> EmployeeUpdate(Employee employee);
        Task<string> EmployeeDelete(Employee employee);
    }
}
