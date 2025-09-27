using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Route.MVCAPP.DAL.Common;

namespace Route.MVCAPP.DAL.Models.Employees
{
    #region Part 3 Employee Module - Entities , Configs , Migration
    public class Employee : ModelBase
    {
        public string Name { get; set; } = null!;

        public string? Address { get; set; }
        public DateTime HirringDate { get; set; }
        public string? PhoneNumber { get; set; }
        public decimal Salary { get; set; }
        public int? Age { get; set; }
        public bool IsActive { get; set; }
        public Gender Gender { get; set; }
        public EmployeeType EmployeeType { get; set; }


    } 
    #endregion
}
