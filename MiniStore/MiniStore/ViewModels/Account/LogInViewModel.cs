using System.ComponentModel.DataAnnotations;

namespace MiniStore.ViewModels.Account
{
    public class LogInViewModel
    {
        [Required(ErrorMessage = "Email requis")]
        [EmailAddress(ErrorMessage = "Format invalide")]
        [Display(Name = "Courriel")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mot de passe requis")]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }

        [Display(Name = "Rappel-toi de moi S.V.P.")]
        public bool RememberMe { get; set; }
    }
}