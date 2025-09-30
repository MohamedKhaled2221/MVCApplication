using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Route.MVCAPP.BLL.DTOs.Employees;
using Route.MVCAPP.DAL.Models.Employees;
using Route.MVCAPP.DAL.Persistence.Repositories.Employees;

namespace Route.MVCAPP.BLL.Services.Employees
{
    #region Part 5 Employee Module - Service
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        #region Part 1 IEnummerable vs IQueryable
        public IEnumerable<EmployeeDto> GetAllEmployees()
        {
            var employees = _employeeRepository
                             .GetAllAsQueryable().Where(x => !x.IsDeleted)
                             .Select(employee => new EmployeeDto()
                             {
                                 Id = employee.Id,
                                 Name = employee.Name,
                                 Age = employee.Age,
                                 Salary = employee.Salary,
                                 IsActive = employee.IsActive,
                                 Email = employee.Email,
                                 Gender = employee.Gender.ToString(),
                                 EmployeeType = employee.EmployeeType.ToString()
                             }).ToList();
            return employees;
        }
        //public IEnumerable<EmployeeDto> GetAllEmployees()
        //{
        //    var employees = _employeeRepository
        //                     .GetAll().Where(x => !x.IsDeleted)
        //                     .Select(employee => new EmployeeDto()
        //                     {
        //                         Id = employee.Id,
        //                         Name = employee.Name,
        //                         Age = employee.Age,
        //                         Salary = employee.Salary,
        //                         IsActive = employee.IsActive,
        //                         Email = employee.Email,
        //                         Gender = employee.Gender.ToString(),
        //                         EmployeeType = employee.EmployeeType.ToString()
        //                     }).ToList();
        //    return employees;
        //} 
        #endregion
        public EmployeeDetailsDto? GetEmployeeById(int id)
        {
            var employee = _employeeRepository.GetById(id);
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

            };

            return _employeeRepository.Add(employee);
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

            };


            return _employeeRepository.Update(employee);
        }

        public bool DeleteEmployee(int id)
        {
            var employee = _employeeRepository.GetById(id);
            if (employee is { })

                return _employeeRepository.Delete(employee) > 0;

            return false;

        }






    } 
    #endregion
}
