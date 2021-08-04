using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CqrsMediatoRTest.Product.Queries.GetProduct;
using MediatR;

namespace CqrsMediatoRTest.Product.Handlers.GetProduct
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, IEnumerable<Models.Product>>
    {
        private readonly InMemoryDataStore _inMemoryDataStore;
        public GetProductsHandler(InMemoryDataStore inMemoryDataStore) => _inMemoryDataStore = inMemoryDataStore;
        public async Task<IEnumerable<Models.Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken) => await _inMemoryDataStore.GetAllProducts();
    }
}