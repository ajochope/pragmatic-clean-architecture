namespace Bookify.Domain.Bookings
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Bookify.Domain.Apartments;
    using Bookify.Domain.Users;

    public interface IBookingRepository
    {
        Task<Booking?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<bool> IsOverlappingAsync(
            Apartment apartment,
            DateRange duration,
            CancellationToken cancellationToken = default);
        void Add(Booking booking);
    }
}