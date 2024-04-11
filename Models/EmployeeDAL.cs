using CRUDOperationWithDapper.Interfaces;

namespace CRUDOperationWithDapper.Models
{
    public class EmployeeDAL : IEmployee
    {
        private IDbServices _dbServices;
        public EmployeeDAL(IDbServices dbServices)
        {
            _dbServices = dbServices;
        }

        public async Task<string> EmployeeInsert(Employee employee)
        {
            string result = string.Empty;
            int response = await _dbServices.InsertUpdateDeleteInline<Employee>("INSERT INTO employee (firstname, lastname, mobileno,salary) VALUES (@firstname, @lastname, @mobileno, @salary)", employee);
            if (response != 0)
                result = "Inserted Successfully";            
            else
                result = "Failed to insert";

            return result;
        }

        public async  Task<List<Employee>> getEmployeeList()
        {
            List<Employee> lstemployee = new List<Employee>();
            lstemployee = await _dbServices.SelectInline<Employee>("select firstname,lastname,mobileno,salary from employee order by firstname", null);
            return lstemployee;
        }

        public async Task<string> EmployeeUpdate(Employee employee)
        {
            string result = string.Empty;
            int response = await _dbServices.InsertUpdateDeleteInline<Employee>("Update employee set firstname=@firstname,lastname=@lastname,salary=@salary where mobileno=@mobileno", employee);
            if (response != 0)
                result = "Updated Successfully";
            else
                result = "Failed to Update";

            return result;
        }
        public async Task<string> EmployeeDelete(Employee employee)
        {
            string result = string.Empty;
            int response = await _dbServices.InsertUpdateDeleteInline<Employee>("Delete from employee where mobileno=@mobileno", employee);
            if (response != 0)
                result = "Deleted Successfully";
            else
                result = "Failed to Delete";

            return result;
        }
    }
}
