namespace Bookify.Application.Bookings.GetBooking
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Bookify.Application.Abstractions.Messaging;
    using Bookify.Domain.Abstractions;
    using Bookify.Domain.Bookings;
    using MediatR;

    public sealed record GetBookingQuery(Guid BookingId) : IQuery<BookingResponse>
    {
        private readonly IBookingRepository _bookingRepository;
        public string CacheKey => $"bookings-{BookingId}";
        public TimeSpan? Expiration => null;
    }
}