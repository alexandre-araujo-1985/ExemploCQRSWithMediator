using MediatR;
using ExemploCQRSWithMediator.Domain.Queries;
using ExemploCQRSWithMediator.Domain.Entities;
using ExemploCQRSWithMediator.Domain.Repositories;

namespace ExemploCQRSWithMediator.Domain.Handlers;

public class ObterClientePorIdHandler : IRequestHandler<ObterClientePorIdQuery, Cliente>
{
	private readonly FakeDataStore _fakeDataStore;

	public ObterClientePorIdHandler(FakeDataStore fakeDataStore)
	{
		_fakeDataStore = fakeDataStore;
	}

	public async Task<Cliente> Handle(ObterClientePorIdQuery request, CancellationToken cancellationToken) =>
		await _fakeDataStore.ObterClientePorId(request.id);
}
