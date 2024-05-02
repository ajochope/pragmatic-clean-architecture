namespace Bookify.Application.Bookings.ReserveBooking
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Bookify.Application.Abstractions.Clock;
    using Bookify.Application.Abstractions.Email;
    using Bookify.Application.Abstractions.Messaging;
    using Bookify.Domain.Abstractions;
    using Bookify.Domain.Apartments;
    using Bookify.Domain.Bookings;
    using Bookify.Domain.Bookings.Events;
    using Bookify.Domain.Users;
    using MediatR;

    internal sealed class BookingReservedDomainEventHandler : INotificationHandler<BookingReservedDomainEvent>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;

        public BookingReservedDomainEventHandler(
            IBookingRepository bookingRepository,
            IUserRepository userRepository,
            IEmailService emailService)
        {
            _bookingRepository = bookingRepository;
            _userRepository = userRepository;
            _emailService = emailService;
        }

        public async Task Handle(BookingReservedDomainEvent notification, CancellationToken cancellationToken)
        {
            Booking? booking = await _bookingRepository.GetByIdAsync(notification.BookingId, cancellationToken);
            if (booking is null)
            {
                return;
            }

            User? user = await _userRepository.GetByIdAsync(booking.UserId, cancellationToken);
            if (user is null)
            {
                return;
            }
            await _emailService.SendAsync(
                user.Email,
                "Booking reserved!",
                "You have 10 minutes to confirm this booking");
        }
    }
}