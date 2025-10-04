using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Route.MVCAPP.BLL.Common.Service.Attachments;
using Route.MVCAPP.BLL.DTOs.Employees;
using Route.MVCAPP.DAL.Models.Employees;
using Route.MVCAPP.DAL.Persistence.Repositories.Employees;
using Route.MVCAPP.DAL.Persistence.UnitOfWork;

namespace Route.MVCAPP.BLL.Services.Employees
{
    #region Part 5 Employee Module - Service
    public class EmployeeService : IEmployeeService
    {
     
        private readonly IUnitOfWork _unitofwork;
        private readonly IAttachmentService _attachmentService;
        private readonly IMapper _mapper;

        public EmployeeService(IUnitOfWork unitOfWork , IAttachmentService attachmentService , IMapper mapper)
        {
            _unitofwork = unitOfWork;
            _attachmentService = attachmentService;
            _mapper = mapper;
        }

        #region Part 1 IEnummerable vs IQueryable
        public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync(string search)
        {
            var employees =await _unitofwork.EmployeeRepository
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
                                 Department = employee.Department.Name,
                                 Image = employee.Image
                             }).ToListAsync();
            return employees;
        }
       
        #endregion
        public async Task<EmployeeDetailsDto?> GetEmployeeByIdAsync(int id)
        {
            var employee = await _unitofwork.EmployeeRepository.GetAsync(id);
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
                    Department = employee.Department?.Name ?? "",
                    Image = employee.Image
      
                };
            return null;


        }
        public async Task<int> CreateEmployeeAsync(CreatedEmployeeDto employeeDto)
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
            #region Part 6 Refactor CreateEnployee Action - Upload Image 
            if (employeeDto.Image is not null)
                employee.Image =await _attachmentService.UploadAsync(employeeDto.Image, "Images"); 
            #endregion

            _unitofwork.EmployeeRepository.Add(employee);
          return await _unitofwork.CompleteAsync();
        }
        public async Task<int> UpdateEmployeeAsync(UpdatedEmployeeDto employeeDto)
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
                DepartmentId = employeeDto.DepartmentId,

            };


            _unitofwork.EmployeeRepository.Update(employee);
            return await _unitofwork.CompleteAsync();
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var employeeRepository = _unitofwork.EmployeeRepository;
            var employee = await employeeRepository.GetAsync(id);
            if (employee is { })

                 employeeRepository.Delete(employee) ;

            return await _unitofwork.CompleteAsync() > 0;

        }






    } 
    #endregion
}
