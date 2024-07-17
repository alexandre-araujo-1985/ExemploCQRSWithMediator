using ExemploCQRSWithMediator.Domain.Entities;

namespace ExemploCQRSWithMediator.Domain.Repositories;

public class FakeDataStore
{
	private readonly List<Cliente> _clientes;

	public FakeDataStore()
	{
		_clientes = new List<Cliente>
		{
			new Cliente { Id = 1, Nome = "Nair"},
			new Cliente { Id = 2, Nome = "Dany"},
			new Cliente { Id = 3, Nome = "Miguel"}
		};
	}

	public async Task AdicionarCliente(Cliente cliente)
	{
		_clientes.Add(cliente);
		await Task.CompletedTask;
	}

	public async Task<IEnumerable<Cliente>> ListarClientes() =>
		await Task.FromResult(_clientes);

	public async Task<Cliente> ObterClientePorId(int id) =>
		await Task.FromResult(_clientes.Single(c => c.Id == id));

	public async Task EventoOcorrido(Cliente cliente, string evento)
	{
		_clientes.Single(c => c.Id == cliente.Id).Nome = $"{cliente.Nome} evento: {evento}";
		await Task.CompletedTask;
	}
}
