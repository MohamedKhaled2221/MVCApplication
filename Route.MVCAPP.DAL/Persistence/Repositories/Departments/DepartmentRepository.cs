using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Route.MVCAPP.DAL.Models.Departments;
using Route.MVCAPP.DAL.Persistence.Data.Contexts;


namespace Route.MVCAPP.DAL.Persistence.Repositories.Departments
{
    #region Part 5 Department Repository - DAL
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public DepartmentRepository(ApplicationDbContext dbContext)
        { // Dependency Injection -> Make CLR make Object from ApplicationDbContext and Inject it here

            _dbContext = dbContext;
        }

        public Department? GetById(int id)
        {
            return _dbContext.Find<Department>(id);

        }
        public IEnumerable<Department> GetAll(bool withNoTracking = true)
        {
            if (withNoTracking)
            {
                return _dbContext.Departments.AsNoTracking().ToList(); // Detached
            }
            else
            {
                return _dbContext.Departments.ToList();   // unchanged
            }
        }
        public IQueryable<Department> GetAllAsQueryable()
        {
         return _dbContext.Departments;
        }


        public int Add(Department entity)
        {
            _dbContext.Departments.Add(entity);
            return _dbContext.SaveChanges();
        }

        public int Delete(Department entity)
        {
            _dbContext.Departments.Remove(entity);
            return _dbContext.SaveChanges();
        }




        public int Update(Department entity)
        {
            _dbContext.Departments.Update(entity);
            return _dbContext.SaveChanges();
        }

        
    } 
    #endregion
}
