using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Route.MVCAPP.DAL.Models.Employees;
using Route.MVCAPP.DAL.Persistence.Data.Contexts;
using Route.MVCAPP.DAL.Persistence.Repositories._Generic;

namespace Route.MVCAPP.DAL.Persistence.Repositories.Employees
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            
        }
    }
    
    }

