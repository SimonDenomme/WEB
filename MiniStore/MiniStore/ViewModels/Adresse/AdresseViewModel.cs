using FluentValidation;
using MiniStore.ViewModels.Command;
using System;
using System.ComponentModel.DataAnnotations;


namespace MiniStore.ViewModels.Adresse
{
    public class AdresseViewModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "Street Number")]
        public int AddressNumber { get; set; }
        [Required]
        [Display(Name = "Street Name")]
        public string AddressStreet { get; set; }
        [Required]
        [Display(Name = "City")]
        public string AddressCity { get; set; }
        [Required]
        [Display(Name = "Postal Code")]
        public string AddressPostalCode { get; set; }
    }
    public class AdresseViewModelValidator : AbstractValidator<AdresseViewModel>
    {
        private const string EMAILREGEX = @"^[A-z\d!\/$%?&*#]{4,30}@[A-z\d]{4,30}.[A-z]{2,5}$";
        private const string PhoneRegex = @"^[0-9]{3,4}-? ?[0-9]{3}-? ?[0-9]{4}$";
        private const string PostalRegex = @"^[A-z]\d[A-z]\s?\d[A-z]\d$";

        public AdresseViewModelValidator()
        {

            RuleFor(x => x.AddressPostalCode)
                .NotEmpty()
                .Matches(PostalRegex)
                    .WithMessage("The postal code must respect the convention, H0H0H0.");
            
        }
    }
}
