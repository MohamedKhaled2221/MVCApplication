using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Route.MVCAPP.DAL.Models.Departments;

namespace Route.MVCAPP.DAL.Persistence.Repositories.Departments
{
    #region Part 5 Department Repository - DAL
    public interface IDepartmentRepository
    {
        // 5 CRUD Operations

        // 1. Get by id
        Department? GetById(int id);
        // 2. Get all
        IEnumerable<Department> GetAll(bool withNoTracking = true);
        IQueryable<Department> GetAllAsQueryable();
        // 3. Add
        int Add(Department entity);
        // 4. Update
        int Update(Department entity);
        // 5. Delete
        int Delete(Department entity);
    } 
    #endregion
}
