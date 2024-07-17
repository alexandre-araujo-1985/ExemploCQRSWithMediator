using MediatR;
using Microsoft.Extensions.Logging;

namespace ExemploCQRSWithMediator.Domain.Behaviors;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
	where TRequest : IRequest<TResponse>
{
	private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;
	public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
		=> _logger = logger;

	public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
	{
		_logger.LogInformation($"Handling {typeof(TRequest).Name}");
		var response = await next();

		_logger.LogInformation($"Handled {typeof(TResponse).Name}");

		return response;
	}
}

//sealed class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
//	where TRequest : notnull
//{
//	public OpenBehavior(ILogger<OpenBehavior<TRequest, TResponse>> logger)
//	{
//		this.logger = logger;
//	}

//	readonly ILogger logger;

//	public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
//	{
//		logger.LogInformation("Invoked");
//		return next();
//	}
//}