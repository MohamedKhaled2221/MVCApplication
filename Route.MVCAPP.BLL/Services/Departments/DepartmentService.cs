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
        public IEnumerable<DepartmentToReturnDto> GetAllDepartments()
        {

            var departments = _unitofwork.DepartmentRepository.GetAllAsQueryable()
                .Select(department => new DepartmentToReturnDto
                {
                    Id = department.Id,
                    Code = department.Code,
                    Name = department.Name,
                    CreationDate = department.CreationDate
                })
                .AsNoTracking()
                .ToList();

            return departments;
        }
        public DepartmentDetailsDto? GetDepartmentById(int id)
        {
            var department = _unitofwork.DepartmentRepository.GetById(id);
            if (department is { })
                return new DepartmentDetailsDto
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

        public int CreateDepartment(CreatedDepartmentDto departmentDto)
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
           return _unitofwork.Complete();
        }

        public bool DeleteDepartment(int id)
        {
            var departemntRepository = _unitofwork.DepartmentRepository;
            var department = departemntRepository.GetById(id);
            if (department is { })
            
                departemntRepository.Delete(department) ;
            
            return _unitofwork.Complete()>0;
        }

        public int UpdateDepartment(UpdatedDepartmentDto departmentDto)
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
            return _unitofwork.Complete();
        }
    }
    #endregion
}
