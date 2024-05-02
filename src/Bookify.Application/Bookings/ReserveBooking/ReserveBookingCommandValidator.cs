namespace Bookify.Application.Bookings.ReserveBooking
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Bookify.Application.Abstractions.Messaging;
    using Bookify.Application.Exceptions;
    using FluentValidation;
    using MediatR;
    using Microsoft.Extensions.Logging;

    internal class ReserveBookingCommandValidator : AbstractValidator<ReserveBookingCommand>
    {
        public ReserveBookingCommandValidator()
        {
            RuleFor(c => c.UserId).NotEmpty();

            RuleFor(c => c.ApartmentId).NotEmpty();

            RuleFor(c => c.StartDate).LessThan(c => c.EndDate);
        }
    }
}