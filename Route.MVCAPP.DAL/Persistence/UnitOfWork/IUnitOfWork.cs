using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Route.MVCAPP.DAL.Persistence.Repositories.Departments;
using Route.MVCAPP.DAL.Persistence.Repositories.Employees;

namespace Route.MVCAPP.DAL.Persistence.UnitOfWork
{
    #region Part 4 Unit Of Work
    public interface IUnitOfWork : IDisposable
    {
        public IEmployeeRepository EmployeeRepository { get; }
        public IDepartmentRepository DepartmentRepository { get; }
        int Complete();
    } 
    #endregion
}
