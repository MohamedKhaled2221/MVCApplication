using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Route.MVCAPP.DAL.Models;
using Route.MVCAPP.DAL.Models.Departments;
using Route.MVCAPP.DAL.Persistence.Data.Contexts;

namespace Route.MVCAPP.DAL.Persistence.Repositories._Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : ModelBase
    {
        private protected readonly ApplicationDbContext _dbContext;
        public GenericRepository(ApplicationDbContext dbContext)
        { // Dependency Injection -> Make CLR make Object from ApplicationDbContext and Inject it here

            _dbContext = dbContext;
        }

        public async Task<T?> GetAsync(int id)
        {
            return await _dbContext.FindAsync<T> (id);

        }
        public async Task<IEnumerable<T>> GetAllAsync(bool withNoTracking = true)
        {
            if (withNoTracking)
            {
                return await _dbContext.Set<T>().Where(x => !x.IsDeleted).AsNoTracking().ToListAsync(); // Detached  
            }
            else
            {
                return await _dbContext.Set<T>().Where(x => !x.IsDeleted).ToListAsync();   // unchanged  
            }
        }
        public IQueryable<T> GetAllAsQueryable()
        {
            return _dbContext.Set<T>();
        }


        public void Add(T entity)=>  _dbContext.Set<T>().Add(entity);
            
        

        public void Delete(T entity)
        {
           entity.IsDeleted = true;
            _dbContext.Set<T>().Remove(entity);
            
        }




        public void Update(T entity)=>  _dbContext.Set<T>().Update(entity);
        


    }
}

