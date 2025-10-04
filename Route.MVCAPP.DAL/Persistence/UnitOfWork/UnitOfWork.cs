using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Route.MVCAPP.DAL.Persistence.Data.Contexts;
using Route.MVCAPP.DAL.Persistence.Repositories.Departments;
using Route.MVCAPP.DAL.Persistence.Repositories.Employees;

namespace Route.MVCAPP.DAL.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _dbContext;

        public IEmployeeRepository EmployeeRepository => new EmployeeRepository(_dbContext);
        public IDepartmentRepository DepartmentRepository => new AttachmentsServices(_dbContext);
        public UnitOfWork(ApplicationDbContext dbContext) {
          _dbContext=dbContext;
        
        }

        public int Complete()
        {
            return _dbContext.SaveChanges();
        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }

        }
}
