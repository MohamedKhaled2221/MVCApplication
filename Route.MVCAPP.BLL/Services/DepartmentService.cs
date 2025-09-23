using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Route.MVCAPP.BLL.DTOs;
using Route.MVCAPP.DAL.Models.Departments;
using Route.MVCAPP.DAL.Persistence.Repositories.Departments;

namespace Route.MVCAPP.BLL.Services
{
    #region Part 6 Department Service and DTOs - BLL
    public class DepartmentService : IDepartmentService
    {
        private IDepartmentRepository _departemntRepository;

        public DepartmentService(IDepartmentRepository departemntRepository)
        {  // Dependency Injection
            _departemntRepository = departemntRepository;
        }
        public IEnumerable<DepartmentToReturnDto> GetAllDepartments()
        {

            var departments = _departemntRepository.GetAllAsQueryable()
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
            var department = _departemntRepository.GetById(id);
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
            return _departemntRepository.Add(departments);
        }

        public bool DeleteDepartment(int id)
        {
            var department = _departemntRepository.GetById(id);
            if (department is { })
            {
                return _departemntRepository.Delete(department) > 0;
            }
            return false;
        }

        public int UpdateDepartment(UpdatedDepartmentDto departmentDto)
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
            return _departemntRepository.Update(departments);
        }
    } 
    #endregion
}
