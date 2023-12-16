using MediatR;
using Microsoft.Extensions.Logging;

namespace MediatrDemo.Application.Behaviours;

public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> _logger;

    public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest, TResponse>> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Start processing request '{requestName}' {@Request}", request.GetType().Name, request);
        var response = await next();
        _logger.LogInformation("End processing request '{requestName}' response {@Response}", request.GetType().Name, response);
        return response;
    }
}
