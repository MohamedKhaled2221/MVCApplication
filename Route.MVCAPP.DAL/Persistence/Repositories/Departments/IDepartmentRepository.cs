using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Route.MVCAPP.DAL.Models.Departments;
using Route.MVCAPP.DAL.Persistence.Repositories._Generic;

namespace Route.MVCAPP.DAL.Persistence.Repositories.Departments
{
    #region Part 5 Department Repository - DAL
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
        
    } 
    #endregion
}
