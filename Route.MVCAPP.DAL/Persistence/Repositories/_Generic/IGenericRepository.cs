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
        Task<T?> GetAsync(int id);
        // 2. Get all
        Task<IEnumerable<T>> GetAllAsync(bool withNoTracking = true);
        IQueryable<T> GetAllAsQueryable();
        // 3. Add
        void Add(T entity);
        // 4. Update
        void Update(T entity);
        // 5. Delete
        void Delete(T entity);
    } 
    #endregion
}
