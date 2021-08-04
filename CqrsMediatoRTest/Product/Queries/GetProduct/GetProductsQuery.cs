using System.Collections.Generic;
using MediatR;

namespace CqrsMediatoRTest.Product.Queries.GetProduct
{
    public record GetProductsQuery() : IRequest<IEnumerable<Models.Product>>;
}