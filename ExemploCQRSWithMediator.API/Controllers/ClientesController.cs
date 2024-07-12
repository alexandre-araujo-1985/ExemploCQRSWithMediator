using MediatR;
using Microsoft.AspNetCore.Mvc;
using ExemploCQRSWithMediator.Domain.Repositories;
using ExemploCQRSWithMediator.Domain.Queries;

namespace ExemploCQRSWithMediator.API.Controllers;

[Route("api/[controller]")]
[ApiController]
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
}
