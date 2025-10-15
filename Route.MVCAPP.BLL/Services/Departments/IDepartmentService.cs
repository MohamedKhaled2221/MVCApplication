using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Route.MVCAPP.BLL.DTOs.Departments;

namespace Route.MVCAPP.BLL.Services.Departments
{
    #region Part 6 Department Service and DTOs - BLL
    public interface IDepartmentService
    {
       Task< IEnumerable<DepartmentToReturnDto>> GetAllDepartmentsAsync();
        Task<DepartmentDetailsDto?> GetDepartmentByIdAsync(int id);
        Task<int> CreateDepartmentAsync(CreatedDepartmentDto departmentDto);
        Task<int> UpdateDepartmentAsync(UpdatedDepartmentDto departmentDto);
        Task<bool> DeleteDepartmentAsync(int id);
    }
    #endregion
}
