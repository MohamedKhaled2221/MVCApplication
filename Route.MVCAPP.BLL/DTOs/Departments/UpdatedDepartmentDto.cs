using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route.MVCAPP.BLL.DTOs.Departments
{
    #region Part 6 Department Service and DTOs - BLL
    public class UpdatedDepartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string Code { get; set; } = null!;
        [Display(Name = "Date Of Creation")]
        public DateOnly CreationDate { get; set; }
    }
    #endregion
}
