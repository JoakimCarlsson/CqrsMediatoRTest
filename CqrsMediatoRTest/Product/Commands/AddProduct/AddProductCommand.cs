using MediatR;

namespace CqrsMediatoRTest.Product.Commands.AddProduct
{
    public record AddProductCommand(Models.Product Product) : IRequest<Models.Product>;
}
