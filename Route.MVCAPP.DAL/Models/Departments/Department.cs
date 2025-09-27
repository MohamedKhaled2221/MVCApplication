using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route.MVCAPP.DAL.Models.Departments
{
    #region Part 3 Department Module ( Entities , Configurations ) 
    public class Department : ModelBase
    {
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string? Description { get; set; }
        public DateOnly CreationDate { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastModifiedOn
        {
            get; set;
        }
        #endregion
    }
}
