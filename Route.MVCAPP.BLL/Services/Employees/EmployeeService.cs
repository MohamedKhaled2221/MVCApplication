using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Route.MVCAPP.BLL.DTOs.Employees;
using Route.MVCAPP.DAL.Models.Employees;
using Route.MVCAPP.DAL.Persistence.Repositories.Employees;
using Route.MVCAPP.DAL.Persistence.UnitOfWork;

namespace Route.MVCAPP.BLL.Services.Employees
{
    #region Part 5 Employee Module - Service
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUnitOfWork _unitofwork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitofwork = unitOfWork;
        }

        #region Part 1 IEnummerable vs IQueryable
        public IEnumerable<EmployeeDto> GetAllEmployees(string search)
        {
            var employees = _unitofwork.EmployeeRepository
                             .GetAllAsQueryable()
                             .Where(E => !E.IsDeleted && (string.IsNullOrEmpty(search) ||E.Name.ToLower().Contains (search.ToLower())))
                             .Select(employee => new EmployeeDto()
                             {
                                 Id = employee.Id,
                                 Name = employee.Name,
                                 Age = employee.Age,
                                 Salary = employee.Salary,
                                 IsActive = employee.IsActive,
                                 Email = employee.Email,
                                 Gender = employee.Gender.ToString(),
                                 EmployeeType = employee.EmployeeType.ToString(),
                                 Department = employee.Department.Name
                             }).ToList();
            return employees;
        }
       
        #endregion
        public EmployeeDetailsDto? GetEmployeeById(int id)
        {
            var employee =  _unitofwork.EmployeeRepository.GetById(id);
            if (employee is { })
                return new EmployeeDetailsDto()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Age = employee.Age,
                    Address = employee.Address,
                    Salary = employee.Salary,
                    IsActive = employee.IsActive,
                    Email = employee.Email,
                    PhoneNumber = employee.PhoneNumber,
                    HiringDate = employee.HirringDate,
                    Gender = employee.Gender,
                    EmployeeType = employee.EmployeeType,
                    Department = employee.Department.Name

                };
            return null;

        }
        public int CreateEmployee(CreatedEmployeeDto employeeDto)
        {
            var employee = new Employee()
            {
                Name = employeeDto.Name,
                Age = employeeDto.Age,
                Address = employeeDto.Address,
                Salary = employeeDto.Salary,
                IsActive = employeeDto.IsActive,
                Email = employeeDto.Email,
                PhoneNumber = employeeDto.PhoneNumber,
                HirringDate = employeeDto.HiringDate,
                Gender = employeeDto.Gender,
                EmployeeType = employeeDto.EmployeeType,
                CreatedBy = 1,
                LastModifiedBy = 1,
                LastModifiedOn = DateTime.Now,
                DepartmentId = employeeDto.DepartmentId

            };

             _unitofwork.EmployeeRepository.Add(employee);
          return  _unitofwork.Complete();
        }
        public int UpdateEmployee(UpdatedEmployeeDto employeeDto)
        {
            var employee = new Employee()
            {
                Id = employeeDto.Id,
                Name = employeeDto.Name,
                Age = employeeDto.Age,
                Address = employeeDto.Address,
                Salary = employeeDto.Salary,
                IsActive = employeeDto.IsActive,
                Email = employeeDto.Email,
                PhoneNumber = employeeDto.PhoneNumber,
                HirringDate = employeeDto.HiringDate,
                Gender = employeeDto.Gender,
                EmployeeType = employeeDto.EmployeeType,
                CreatedBy = 1,
                LastModifiedBy = 1,
                LastModifiedOn = DateTime.Now,
                DepartmentId = employeeDto.DepartmentId

            };


            _unitofwork.EmployeeRepository.Update(employee);
            return _unitofwork.Complete();
        }

        public bool DeleteEmployee(int id)
        {
            var employeeRepository = _unitofwork.EmployeeRepository;
            var employee = employeeRepository.GetById(id);
            if (employee is { })

                 employeeRepository.Delete(employee) ;

            return _unitofwork.Complete() > 0;

        }






    } 
    #endregion
}
