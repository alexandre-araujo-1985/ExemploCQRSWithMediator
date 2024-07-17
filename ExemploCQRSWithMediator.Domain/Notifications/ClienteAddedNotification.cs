using ExemploCQRSWithMediator.Domain.Entities;
using MediatR;

namespace ExemploCQRSWithMediator.Domain.Notifications
{
	public record ClienteAddedNotification(Cliente Cliente) : INotification;
}
