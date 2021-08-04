using System.Threading;
using System.Threading.Tasks;
using CqrsMediatoRTest.Product.Queries.GetProduct;
using MediatR;

namespace CqrsMediatoRTest.Product.Handlers.GetProduct
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Models.Product>
    {
        private readonly InMemoryDataStore _inMemoryDataStore;
        public GetProductByIdHandler(InMemoryDataStore inMemoryDataStore) => _inMemoryDataStore = inMemoryDataStore;
        public async Task<Models.Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken) => await _inMemoryDataStore.GetProductById(request.Id);
    }
}
