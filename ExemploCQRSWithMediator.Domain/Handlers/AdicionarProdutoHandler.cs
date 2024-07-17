using MediatR;
using ExemploCQRSWithMediator.Domain.Commands;
using ExemploCQRSWithMediator.Domain.Entities;
using ExemploCQRSWithMediator.Domain.Repositories;

namespace ExemploCQRSWithMediator.Domain.Handlers;

public class AdicionarProdutoHandler : IRequestHandler<AdicionarClienteCommand, Cliente>
{
	private readonly FakeDataStore _fakeDataStore;

	public AdicionarProdutoHandler(FakeDataStore fakeDataStore)
	{
		_fakeDataStore = fakeDataStore;
	}

	public async Task<Cliente> Handle(AdicionarClienteCommand request, CancellationToken cancellationToken)
	{
		await _fakeDataStore.AdicionarCliente(request.cliente);
		return request.cliente;
	}
}
