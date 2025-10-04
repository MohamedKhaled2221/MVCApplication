using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Route.MVCAPP.BLL.DTOs;
using Route.MVCAPP.BLL.DTOs.Employees;

namespace Route.MVCAPP.BLL.Services.Employees
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync(string search);
        Task<EmployeeDetailsDto?> GetEmployeeByIdAsync(int id);
        Task<int> CreateEmployeeAsync(CreatedEmployeeDto employeeDto);
        Task<int> UpdateEmployeeAsync(UpdatedEmployeeDto employeeDto);
        Task<bool> DeleteEmployeeAsync(int id);
    }
}
