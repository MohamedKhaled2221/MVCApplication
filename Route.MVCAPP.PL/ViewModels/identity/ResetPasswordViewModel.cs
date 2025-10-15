using System.ComponentModel.DataAnnotations;

namespace Route.MVCAPP.PL.ViewModels.identity
{
    public class ResetPasswordViewModel
    {
        [DataType(DataType.Password)]

        public string Password { get; set; } = null!;
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm Password Doesn't Match With Password")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
