using FluentValidation;
using Microsoft.AspNetCore.Mvc.Rendering;
using MiniStore.ViewModels.Cart;
using System;
using System.Collections.Generic;

namespace MiniStore.ViewModels.Command
{
    public class CommandForm
    {
        public Guid Id { get; set; }

        // Infos Clients
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CellPhone { get; set; }

        // DropDownList pour les adresses
        public IEnumerable<SelectListItem> Addresses { get; set; }
        public string SelectedAddress { get; set; }

        // Address
        public int Number { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }

        // Cart
        public CartViewModels.CartViewModel Cart { get; set; }
    }

    public class CommandFormValidator : AbstractValidator<CommandForm>
    {
        private const string EMAILREGEX = @"^[A-z\d!\/$%?&*#]{4,30}@[A-z\d]{4,30}.[A-z]{2,5}$";
        private const string PhoneRegex = @"^[0-9]{3,4}-? ?[0-9]{3}-? ?[0-9]{4}$";

        public CommandFormValidator()
        {
            RuleFor(x => x.Email).Matches(EMAILREGEX).WithMessage("The email must be in the good format (Ex: example@example.com).");

            RuleFor(x => x.PostalCode)
                .NotEmpty()
                    .When(x => x.Number > 0)
                    .WithMessage("The postal code is required.")
                .Matches(@"^[A-z]\d[A-z]\s?\d[A-z]\d$")
                    .WithMessage("The postal code must respect the convention, H0H0H0.");

            RuleFor(x => x.CellPhone)
                .Matches(PhoneRegex)
                    .WithMessage("The phone number must be in the required format. (Ex: 450-123-4567)");
        }
    }

}
