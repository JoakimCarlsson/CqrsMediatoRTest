using FluentValidation;

namespace CqrsMediatoRTest.Product.Commands.AddProduct
{
    public class AddProductCommandValidator : AbstractValidator<AddProductCommand>
    {
        public AddProductCommandValidator()
        {
            RuleFor(x => x.Product.Name).NotEmpty().WithMessage("Name can't be null");
            RuleFor(x => x.Product.Id).NotEmpty().WithMessage("Id can't be null");
        }
    }
}
