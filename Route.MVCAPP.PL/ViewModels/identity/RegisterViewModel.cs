using System.ComponentModel.DataAnnotations;

namespace Route.MVCAPP.PL.ViewModels.identity
{
    public class RegisterViewModel
    {
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is Required")]
        [MaxLength(50)]
        public string FirstName { get; set; } = null!;
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is Required")]
        [MaxLength(50)]
        public string LastName { get; set; } = null!;
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "User Name is Required")]
        [MaxLength(50)]
        public string UserName { get; set; } = null!;
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;
        [DataType(DataType.Password)]

        public string Password { get; set; } = null!;
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm Password Doesn't Match With Password")]
        public string ConfirmPassword { get; set; } = null!;
        public bool IsAgree { get; set; }


    }
}
