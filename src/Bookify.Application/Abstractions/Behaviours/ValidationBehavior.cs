namespace Bookify.Application.Abstractions.Behaviours
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Bookify.Application.Abstractions.Messaging;
    using Bookify.Application.Exceptions;
    using FluentValidation;
    using MediatR;
    using Microsoft.Extensions.Logging;

    internal sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IBaseCommand
    {
        private readonly ILogger<TRequest> _logger;
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(ILogger<TRequest> logger, IValidator<TRequest> validator)
        {
            _logger = logger;
            _validators = new List<IValidator<TRequest>> { validator };
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if(!_validators.Any())
            {
                return await next();
            }
            var context = new ValidationContext<TRequest>(request);
            var validationErrors = _validators
                .Select(validator => validator.Validate(context))
                .Where(validationResult => validationResult.Errors.Any())
                .SelectMany(validationResult => validationResult.Errors)
                .Select(validationFailure => new ValidationError(
                    validationFailure.PropertyName,
                    validationFailure.ErrorMessage
                ))
                .ToList();
            if (validationErrors.Any())
            {
                throw new Exceptions.ValidationException(validationErrors);
            }
            return await next();
        }
    }
}