using System.ComponentModel.DataAnnotations;

namespace Route.MVCAPP.PL.ViewModels.identity
{
    public class ForgetPasswordViewModel
    {
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;
    }
}
