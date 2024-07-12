using MediatR;
using ExemploCQRSWithMediator.Domain.Entities;

namespace ExemploCQRSWithMediator.Domain.Queries;

public record ObterClientesQuery() : IRequest<IEnumerable<Cliente>>;

