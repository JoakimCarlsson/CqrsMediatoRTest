using MediatR;

namespace CqrsMediatoRTest.Product.Queries.GetProduct
{
    public record GetProductByIdQuery (int Id) : IRequest<Models.Product>;
}