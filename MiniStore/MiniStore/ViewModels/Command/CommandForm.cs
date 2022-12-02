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
        public string FirstName { get; set; }
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
        
        public int Number { get; set; }
        public string Street { get; set; }
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
            RuleFor(x => x.Email)
                .NotEmpty()
                .Matches(EMAILREGEX).WithMessage("The email must be in the good format (Ex: example@example.com).");


            //La validation du code postal pose un pb pour eenvoyer le formulaire à cause de dropdown list
            RuleFor(x => x.PostalCode)
                .NotEmpty()
                .Matches(PostalRegex)
                    .WithMessage("The postal code must respect the convention, H0H0H0.");

            RuleFor(x => x.CellPhone)
                .NotEmpty()
                .Matches(PhoneRegex)
                    .WithMessage("The phone number must be in the required format. (Ex: 450-123-4567)");
        }
    }

}
