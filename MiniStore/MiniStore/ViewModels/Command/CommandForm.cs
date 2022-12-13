using FluentValidation;
using Microsoft.AspNetCore.Mvc.Rendering;
using MiniStore.ViewModels.Cart;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MiniStore.ViewModels.Command
{
    public class CommandForm
    {
        public Guid Id { get; set; }

        // Infos Clients
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string CellPhone { get; set; }

        // DropDownList pour les adresses
        public IEnumerable<SelectListItem> Addresses { get; set; }
        public string SelectedAddress { get; set; }

        // Address
        public Guid? AdresseId { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string PostalCode { get; set; }

        // Cart
        public CartViewModels.CartViewModel Cart { get; set; }
    }

    public class CommandFormValidator : AbstractValidator<CommandForm>
    {
        private const string EMAILREGEX = @"^[A-z\d!\/$%?&*#]{4,30}@[A-z\d]{4,30}.[A-z]{2,5}$";
        private const string PhoneRegex = @"^[0-9]{3,4}-? ?[0-9]{3}-? ?[0-9]{4}$";
        private const string PostalRegex = @"^[A-z]\d[A-z]\s?\d[A-z]\d$";

        public CommandFormValidator()
        {
            RuleFor(x => x.FirstName)
               .NotEmpty()
                   .WithMessage("The first name of the client is required.")
               .MinimumLength(3)
                   .WithMessage("The first name must be at least 3 characters long.");

            RuleFor(x => x.LastName)
                .NotEmpty()
                    .WithMessage("The last name of the client is required.")
                .MinimumLength(3)
                    .WithMessage("The first name must be at least 3 characters long.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .Matches(EMAILREGEX).WithMessage("The email must be in the good format (Ex: example@example.com).");

            RuleFor(x => x.Number)
                .GreaterThan(0)
                    .WithMessage("The address can't be 0 or below.");

            RuleFor(x => x.Street)
                .NotEmpty()
                    .When(x => x.Number > 0)
                        .WithMessage("The street must be specified.");

            RuleFor(x => x.City)
                .NotEmpty()
                    .When(x => x.Number > 0)
                        .WithMessage("The city must be specified.");

            //La validation du code postal pose un pb pour eenvoyer le formulaire à cause de dropdown list
            RuleFor(x => x.PostalCode)
                .NotEmpty()
                    .When(x => x.Number > 0)
                .Matches(PostalRegex)
                    .WithMessage("The postal code must respect the convention, H0H0H0.");

            RuleFor(x => x.CellPhone)
                .NotEmpty()
                .Matches(PhoneRegex)
                    .WithMessage("The phone number must be in the required format. (Ex: 450-123-4567)");
        }
    }

}
