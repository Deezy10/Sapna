using System.ComponentModel.DataAnnotations;

namespace SapnaWebsite.ViewModels.Account
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
