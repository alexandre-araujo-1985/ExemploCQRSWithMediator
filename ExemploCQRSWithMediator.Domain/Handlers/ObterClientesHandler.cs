using MediatR;
using ExemploCQRSWithMediator.Domain.Entities;
using ExemploCQRSWithMediator.Domain.Repositories;
using ExemploCQRSWithMediator.Domain.Queries;

namespace ExemploCQRSWithMediator.Domain.Handlers;

public class ObterClientesHandler : IRequestHandler<ObterClientesQuery, IEnumerable<Cliente>>
{
	private readonly FakeDataStore _fakeDataStore;

	public ObterClientesHandler(FakeDataStore fakeDataStore)
	{
		_fakeDataStore = fakeDataStore;
	}

	public async Task<IEnumerable<Cliente>> Handle(ObterClientesQuery request, CancellationToken cancellationToken) =>
		await _fakeDataStore.ListarClientes();
}
