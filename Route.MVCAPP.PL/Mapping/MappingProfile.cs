using AutoMapper;
using Route.MVCAPP.BLL.DTOs.Departments;
using Route.MVCAPP.BLL.DTOs.Employees;
using Route.MVCAPP.DAL.Models.Employees;
using Route.MVCAPP.PL.ViewModels.Departments;

namespace Route.MVCAPP.PL.Mapping
{
    #region Part 3 Mapping using AutoMapper
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Employee
            CreateMap<EmployeeDetailsDto, CreatedEmployeeDto>();
            CreateMap<CreatedEmployeeDto, UpdatedEmployeeDto>();
            CreateMap<Employee, EmployeeDetailsDto>();
            #endregion


            #region Department
            CreateMap<DepartmentDetailsDto, DepartmentViewModel>();
            CreateMap<DepartmentViewModel, UpdatedDepartmentDto>();
            CreateMap<DepartmentViewModel, CreatedDepartmentDto>();
            #endregion
        }
    } 
    #endregion
}
