using MediatR;
using ExemploCQRSWithMediator.Domain.Entities;

namespace ExemploCQRSWithMediator.Domain.Queries;

public record ObterClientePorIdQuery(int id) : IRequest<Cliente>;
