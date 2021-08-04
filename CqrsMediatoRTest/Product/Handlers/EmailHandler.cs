using System.Threading;
using System.Threading.Tasks;
using CqrsMediatoRTest.Product.Notifications;
using MediatR;

namespace CqrsMediatoRTest.Product.Handlers
{
    public class EmailHandler : INotificationHandler<ProductAddedNotification>
    {
        private readonly InMemoryDataStore _fakeDataStore;
        public EmailHandler(InMemoryDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;
        public async Task Handle(ProductAddedNotification notification, CancellationToken cancellationToken)
        {
            await _fakeDataStore.EventOccured(notification.Product, "Email sent ");
            await Task.CompletedTask;
        }
    }
}