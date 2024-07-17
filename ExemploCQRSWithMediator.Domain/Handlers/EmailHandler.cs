using MediatR;
using ExemploCQRSWithMediator.Domain.Repositories;
using ExemploCQRSWithMediator.Domain.Notifications;

namespace ExemploCQRSWithMediator.Domain.Handlers;

public class EmailHandler : INotificationHandler<ClienteAddedNotification>
{
	private readonly FakeDataStore _fakeDataStore;

	public EmailHandler(FakeDataStore fakeDataStore)
	{
		_fakeDataStore = fakeDataStore;
	}

	public async Task Handle(ClienteAddedNotification notification, CancellationToken cancellationToken)
	{
		await _fakeDataStore.EventoOcorrido(notification.Cliente, "Email enviado!");
		await Task.CompletedTask;
	}
}
