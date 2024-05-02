namespace Bookify.Application.Abstractions.Behaviours
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Bookify.Application.Abstractions.Messaging;
    using MediatR;
    using Microsoft.Extensions.Logging;

    internal sealed  class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IBaseCommand
    {
        private readonly ILogger<TRequest> _logger;

        public LoggingBehavior(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var name = request.GetType().Name;
            try 
            {
                _logger.LogInformation("Handling Command..{Command}", name);
                var result = await next();
                _logger.LogInformation("Command {Command} - processed successfully", name);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error handling {Command} - processed failed", name);
                throw;
            }
        }
    }
}