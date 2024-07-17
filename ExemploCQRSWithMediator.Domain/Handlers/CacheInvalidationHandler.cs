using ExemploCQRSWithMediator.Domain.Notifications;
using ExemploCQRSWithMediator.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploCQRSWithMediator.Domain.Handlers
{
	public class CacheInvalidationHandler : INotificationHandler<ClienteAddedNotification>
	{
		private readonly FakeDataStore _fakeDataStore;

		public CacheInvalidationHandler(FakeDataStore fakeDataStore)
		{
			_fakeDataStore = fakeDataStore;
		}

		public async Task Handle(ClienteAddedNotification notification, CancellationToken cancellationToken)
		{
			await _fakeDataStore.EventoOcorrido(notification.Cliente, "Cache Invalidado");
			await Task.CompletedTask;
		}
	}
}
