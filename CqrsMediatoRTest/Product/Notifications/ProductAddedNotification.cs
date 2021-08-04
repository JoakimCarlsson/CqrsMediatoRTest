using MediatR;

namespace CqrsMediatoRTest.Product.Notifications
{
    public record ProductAddedNotification(Models.Product Product) : INotification;
}
