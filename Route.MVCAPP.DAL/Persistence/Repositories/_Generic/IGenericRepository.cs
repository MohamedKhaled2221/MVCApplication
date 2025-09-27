using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Route.MVCAPP.DAL.Models;
using Route.MVCAPP.DAL.Models.Departments;

namespace Route.MVCAPP.DAL.Persistence.Repositories._Generic
{
    #region Part 4 Employee Module - Repository [ Generic Repository ]
    public interface IGenericRepository<T> where T : ModelBase
    {
        // 5 CRUD Operations

        // 1. Get by id
        T? GetById(int id);
        // 2. Get all
        IEnumerable<T> GetAll(bool withNoTracking = true);
        IQueryable<T> GetAllAsQueryable();
        // 3. Add
        int Add(T entity);
        // 4. Update
        int Update(T entity);
        // 5. Delete
        int Delete(T entity);
    } 
    #endregion
}
