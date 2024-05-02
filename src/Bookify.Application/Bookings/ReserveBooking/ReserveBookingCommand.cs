namespace Bookify.Application.Abstractions.Messaging
{
    using Bookify.Application.Abstractions.Messaging;
    public sealed record ReserveBookingCommand(
        Guid ApartmentId,
        Guid UserId,
        DateOnly StartDate,
        DateOnly EndDate) : ICommand<Guid>;
}