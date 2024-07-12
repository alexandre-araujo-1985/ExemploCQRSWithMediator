using MediatR;

namespace ExemploCQRSWithMediator.Domain;

public interface ISender
{
	Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default);
	Task<object?> Send(object request, CancellationToken cancellationToken = default);
}
