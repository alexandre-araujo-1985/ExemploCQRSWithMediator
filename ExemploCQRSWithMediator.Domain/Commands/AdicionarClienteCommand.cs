using MediatR;
using ExemploCQRSWithMediator.Domain.Entities;

namespace ExemploCQRSWithMediator.Domain.Commands
{
	public record AdicionarClienteCommand(Cliente cliente) : IRequest<Cliente>;
}
