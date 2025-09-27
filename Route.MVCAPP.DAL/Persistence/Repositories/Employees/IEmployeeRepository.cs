using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Route.MVCAPP.DAL.Models.Employees;
using Route.MVCAPP.DAL.Persistence.Repositories._Generic;

namespace Route.MVCAPP.DAL.Persistence.Repositories.Employees
{
    public interface IEmployeeRepository :  IGenericRepository<Employee>
    {
    }
}
