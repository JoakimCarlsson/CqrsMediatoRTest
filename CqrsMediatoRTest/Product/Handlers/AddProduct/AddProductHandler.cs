using System.Threading;
using System.Threading.Tasks;
using CqrsMediatoRTest.Product.Commands.AddProduct;
using CqrsMediatoRTest.Product.Notifications;
using MediatR;

namespace CqrsMediatoRTest.Product.Handlers.AddProduct
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, Models.Product>
    {
        private readonly InMemoryDataStore _inMemoryDataStore;
        private readonly IMediator _mediator;

        public AddProductHandler(InMemoryDataStore inMemoryDataStore, IMediator mediator)
        {
            _inMemoryDataStore = inMemoryDataStore;
            _mediator = mediator;
        }

        public async Task<Models.Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            await _inMemoryDataStore.AddProduct(request.Product);
            await _mediator.Publish(new ProductAddedNotification(request.Product));

            return request.Product;
        }
    }


    //public class AddProductHandler : IRequestHandler<AddProductCommand, Unit>
    //{
    //    private readonly InMemoryDataStore _inMemoryDataStore;
    //    public AddProductHandler(InMemoryDataStore inMemoryDataStore) => _inMemoryDataStore = inMemoryDataStore;
    //    public async Task<Unit> Handle(AddProductCommand request, CancellationToken cancellationToken)
    //    {
    //        await _inMemoryDataStore.AddProduct(request.Product);

    //        return Unit.Value;
    //    }
    //}
}