using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Route.MVCAPP.BLL.DTOs.Departments;
using Route.MVCAPP.DAL.Models.Departments;
using Route.MVCAPP.DAL.Persistence.Repositories.Departments;
using Route.MVCAPP.DAL.Persistence.UnitOfWork;

namespace Route.MVCAPP.BLL.Services.Departments
{
    #region Part 6 Department Service and DTOs - BLL
    public class DepartmentService : IDepartmentService
    {
        
        private readonly IUnitOfWork _unitofwork;

        public DepartmentService(IUnitOfWork unitOfWork)
        {  // Dependency Injection
          
            _unitofwork = unitOfWork;
        }
        public async Task<IEnumerable<DepartmentToReturnDto>> GetAllDepartmentsAsync()
        {

            var departments =await _unitofwork.DepartmentRepository.GetAllAsQueryable()
                .Select(department => new DepartmentToReturnDto
                {
                    Id = department.Id,
                    Code = department.Code,
                    Name = department.Name,
                    CreationDate = department.CreationDate
                })
                .AsNoTracking()
                .ToListAsync();

            return  departments;
        }
        public async Task<DepartmentDetailsDto?> GetDepartmentByIdAsync(int id)
        {
            var department =await  _unitofwork.DepartmentRepository.GetAsync(id);
            if (department is { })
                return  new DepartmentDetailsDto
                {
                    Id = department.Id,
                    Name = department.Name,
                    Code = department.Code,
                    CreationDate = department.CreationDate,
                    IsDeleted = department.IsDeleted,
                    CreatedBy = department.CreatedBy,
                    CreatedOn = department.CreatedOn,
                    LastModifiedBy = department.LastModifiedBy,
                    LastModifiedOn = department.LastModifiedOn
                };
            return null;
        }

        public async Task<int> CreateDepartmentAsync(CreatedDepartmentDto departmentDto)
        {
            var departments = new Department
            {
                Name = departmentDto.Name,
                Description = departmentDto.Description,
                Code = departmentDto.Code,
                CreationDate = departmentDto.CreationDate,
                CreatedBy = 1,
                LastModifiedBy = 1,
                LastModifiedOn = DateTime.Now,

            };
            _unitofwork.DepartmentRepository.Add(departments);
           return await _unitofwork.CompleteAsync();
        }

        public async Task<bool> DeleteDepartmentAsync(int id)
        {
            var departemntRepository =  _unitofwork.DepartmentRepository;
            var department =await departemntRepository.GetAsync(id);
            if (department is { })
            
                departemntRepository.Delete(department) ;
            
            return await  _unitofwork.CompleteAsync()>0;
        }

        public async Task<int> UpdateDepartmentAsync(UpdatedDepartmentDto departmentDto)
        {
            var departments = new Department
            {
                Id = departmentDto.Id,
                Name = departmentDto.Name,
                Description = departmentDto.Description,
                Code = departmentDto.Code,
                CreationDate = departmentDto.CreationDate,
                CreatedBy = 1,
                LastModifiedBy = 1,
                LastModifiedOn = DateTime.Now,

            };
            _unitofwork.DepartmentRepository.Update(departments);
            return await _unitofwork.CompleteAsync();
        }
    }
    #endregion
}
