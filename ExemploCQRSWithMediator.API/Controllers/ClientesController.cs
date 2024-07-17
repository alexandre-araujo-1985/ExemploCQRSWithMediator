using MediatR;
using Microsoft.AspNetCore.Mvc;
using ExemploCQRSWithMediator.Domain.Queries;
using ExemploCQRSWithMediator.Domain.Entities;
using ExemploCQRSWithMediator.Domain.Commands;
using ExemploCQRSWithMediator.Domain.Notifications;

namespace ExemploCQRSWithMediator.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
	private readonly IMediator _mediator;

	public ClientesController(IMediator mediator)
	{
		_mediator = mediator;
	}

	[HttpGet]
	public async Task<IActionResult> ListarClientes()
	{
		var clientes = await _mediator.Send(new ObterClientesQuery());

		return Ok(clientes);
	}

	[HttpGet("{id}", Name = "ObterClientePorId")]
	public async Task<IActionResult> ObterClientePorId(int id)
	{
		var cliente = await _mediator.Send(new ObterClientePorIdQuery(id));

		return Ok(cliente);
	}

	[HttpPost]
	public async Task<IActionResult> AdicionarCliente([FromBody] Cliente cliente)
	{
		var clienteToReturn = await _mediator.Send(new AdicionarClienteCommand(cliente));

		await _mediator.Publish(new ClienteAddedNotification(clienteToReturn));

		return CreatedAtRoute("ObterClientePorId", new { id = clienteToReturn.Id }, clienteToReturn);
	}
}
