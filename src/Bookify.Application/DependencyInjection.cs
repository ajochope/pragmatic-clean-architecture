namespace Bookify.Application
{
    using Microsoft.Extensions.DependencyInjection;
    using MediatR;
    using Bookify.Domain.Bookings;
    using Bookify.Application.Abstractions.Behaviours;
    using FluentValidation;

    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(configuration => 
            {
                configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
                configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
                configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });
            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
            services.AddTransient<PricingService>();

            return services;
        }
    }
}