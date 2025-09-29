using System.ComponentModel.DataAnnotations;

namespace Route.MVCAPP.PL.ViewModels.Departments
{
    public class DepartmentEditViewModel

    {
        

        [Required(ErrorMessage = "Code is required.")]
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        [Display(Name = "Date of Creation")]
        public DateOnly CreationDate { get; set; }
}
}
