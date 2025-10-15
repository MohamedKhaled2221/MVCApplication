using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route.MVCAPP.BLL.DTOs.Departments
{
    #region Part 6 Department Service and DTOs - BLL
    public class CreatedDepartmentDto
    {
        [Required(ErrorMessage = "The Name Field is Required ")]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        [Required(ErrorMessage = "The Code Field is Required ")]
        public string Code { get; set; } = null!;
        [Display(Name = "Date Of Creation")]
        public DateOnly CreationDate { get; set; }

    }
    #endregion
}
