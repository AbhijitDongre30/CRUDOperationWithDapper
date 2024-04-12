using CRUDOperationWithDapper.Interfaces;
using CRUDOperationWithDapper.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDOperationWithDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        
        private IEmployee _employee;

        public EmployeeController(IEmployee employee)
        {
            _employee = employee;
        }

        [HttpGet("GetEmployeeList")]
        public async Task<IActionResult> GetEmployeeList()
        {
            return Ok(await _employee.getEmployeeList());
        }

        [HttpPost("EmployeeInsert")]
        public async Task<IActionResult> EmployeeInsert(Employee employee)
        {
            return Ok(await _employee.EmployeeInsert(employee));
        }

        [HttpPost("EmployeeUpdate")]
        public async Task<IActionResult> EmployeeUpdate(Employee employee)
        {
            return Ok(await _employee.EmployeeUpdate(employee));
        }

        [HttpPost("EmployeeDelete")]
        public async Task<IActionResult> EmployeeDelete(Employee employee)
        {
            return Ok(await _employee.EmployeeDelete(employee));
        }

        [HttpGet("GetEmployeeListFunc")]
        public async Task<IActionResult> GetEmployeeListFunc()
        {
            return Ok(await _employee.getEmployeeListWithfunc());
        }

        [HttpPost("EmployeeInsertProc")]
        public async Task<IActionResult> EmployeeInsertProc(Employee employee)
        {
            await _employee.EmployeeInsertProc(employee);
            return Ok();
        }
    }
}
