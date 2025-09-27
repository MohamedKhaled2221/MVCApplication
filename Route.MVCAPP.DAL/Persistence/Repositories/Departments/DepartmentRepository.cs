using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Route.MVCAPP.DAL.Models.Departments;
using Route.MVCAPP.DAL.Persistence.Data.Contexts;
using Route.MVCAPP.DAL.Persistence.Repositories._Generic;


namespace Route.MVCAPP.DAL.Persistence.Repositories.Departments
{
    #region Part 5 Department Repository - DAL
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

    }
    #endregion
}
