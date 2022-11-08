using FluentValidation;
using MiniStore.Domain;
using MiniStore.ViewModels.Cart;

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

        // Cart ?
        public CartViewModels.CartViewModel Cart { get; set; }
    }
    
    public class CommandValidator : AbstractValidator<CommandModel>
    {
        private const string EMAILREGEX = @"^[A-z\d!\/$%?&*#]{4,30}@[A-z\d]{4,30}.[A-z]{2,5}$";

        public CommandValidator()
        {
            //RuleFor(x => x.Email).Matches(EMAILREGEX).WithMessage("The email must be in the good format (Ex: example@example.com).")

            RuleFor(x => x.PostalCode)
                .NotEmpty()
                    .When(x => x.Number > 0)
                    .WithMessage("The postal code is required.")
                .Matches(@"^[A-z]\d[A-z]\s?\d[A-z]\d$")
                    .WithMessage("The postal code must respect the convention, H0H0H0.");
        }
    }
}
