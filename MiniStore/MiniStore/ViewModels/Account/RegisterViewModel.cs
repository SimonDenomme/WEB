using System.ComponentModel.DataAnnotations;

namespace MiniStore.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Email requis")]
        [EmailAddress(ErrorMessage = "Email format invalide")]
        [Display(Name = "Courriel")]
        public string Email { get; set; }

        [Required(ErrorMessage = "PasswordRequiredError")]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }

        [Required(ErrorMessage = "PasswordRequiredError")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmer votre mot de passe")]
        public string ConfirmPassword { get; set; }

        [EnumDataType(typeof(Role))]
        [Display(Name = "Role")]
        public Role RoleUser { get; set; } = Role.Utilisateur;


        public enum Role
        {
            Administrateur = 1,
            Gerant = 2,
            Commis = 3,
            Utilisateur = 4
        };


    }
}
