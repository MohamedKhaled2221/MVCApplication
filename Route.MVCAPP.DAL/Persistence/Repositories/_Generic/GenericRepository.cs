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

        public T? GetById(int id)
        {
            return _dbContext.Find<T> (id);

        }
        public IEnumerable<T> GetAll(bool withNoTracking = true)
        {
            if (withNoTracking)
            {
                return _dbContext.Set<T>().Where(x => !x.IsDeleted).AsNoTracking().ToList(); // Detached  
            }
            else
            {
                return _dbContext.Set<T>().Where(x => !x.IsDeleted).ToList();   // unchanged  
            }
        }
        public IQueryable<T> GetAllAsQueryable()
        {
            return _dbContext.Set<T>();
        }


        public int Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            return _dbContext.SaveChanges();
        }

        public int Delete(T entity)
        {
            entity.IsDeleted = true;
            _dbContext.Set<T>().Update(entity);
            return _dbContext.SaveChanges();
        }




        public int Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            return _dbContext.SaveChanges();
        }


    }
}

