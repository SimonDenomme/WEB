using System.ComponentModel.DataAnnotations;

namespace MiniStore.ViewModels.Account
{
    public class LogInViewModel
    {

        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}