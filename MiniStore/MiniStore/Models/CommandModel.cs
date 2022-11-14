using FluentValidation;
using Microsoft.AspNetCore.Mvc.Rendering;
using MiniStore.Domain;
using System.Collections.Generic;

namespace MiniStore.Models
{
    public class CommandModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }  //pas une bonne idee de là'exposer ici je pense
        public bool IsSent { get; set; } = false;   //utilisé pour le statut annulée ou pas

        // Address
        public int AddressId { get; set; }
        public int Number { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }

        // DropDownList pour les adresses
        public IEnumerable<SelectListItem> Addresses { get; set; }
        public string SelectedAddress { get; set; }

        // Je suis moins sur de ceux qui suive (je = Simon)
        public Address Adresse { get; set; }
        public Cart Cart { get; set; }
        public List<ItemInCart> Items { get; set; }
        public ApplicationUser CommandUser { get; set; }
    }

    public class CommandValidator : AbstractValidator<CommandModel>
    {
        private const string EMAILREGEX = @"^[A-z\d!\/$%?&*#]{4,30}@[A-z\d]{4,30}.[A-z]{2,5}$";
        private const string PhoneRegex = @"^[0-9]{3,4}-? ?[0-9]{3}-? ?[0-9]{4}$";

        public CommandValidator()
        {
            //RuleFor(x => x.Email).Matches(EMAILREGEX).WithMessage("The email must be in the good format (Ex: example@example.com).")

            RuleFor(x => x.PostalCode)
                .NotEmpty()
                    .When(x => x.Number > 0)
                    .WithMessage("The postal code is required.")
                .Matches(@"^[A-z]\d[A-z]\s?\d[A-z]\d$")
                    .WithMessage("The postal code must respect the convention, H0H0H0.");

            //RuleFor(x => x.PhoneNumber)
            //    .Matches(PhoneRegex)
            //        .WithMessage("The phone number must be in the required format. (Ex: 450-123-4567)");
        }
    }
}
