using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Route.MVCAPP.DAL.Models.Employees;

namespace Route.MVCAPP.DAL.Models.Departments
{
    #region Part 3 Department Module ( Entities , Configurations ) 
    public class Department : ModelBase
    {
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string? Description { get; set; }
        public DateOnly CreationDate { get; set; }

        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();

        #endregion
    }
}
