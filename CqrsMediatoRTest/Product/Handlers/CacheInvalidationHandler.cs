using System.Threading;
using System.Threading.Tasks;
using CqrsMediatoRTest.Product.Notifications;
using MediatR;

namespace CqrsMediatoRTest.Product.Handlers
{
    public class CacheInvalidationHandler : INotificationHandler<ProductAddedNotification>
    {
        private readonly InMemoryDataStore _fakeDataStore;
        public CacheInvalidationHandler(InMemoryDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;
        public async Task Handle(ProductAddedNotification notification, CancellationToken cancellationToken)
        {
            await _fakeDataStore.EventOccured(notification.Product, "Cache Invalidated ");
            await Task.CompletedTask;
        }
    }
}