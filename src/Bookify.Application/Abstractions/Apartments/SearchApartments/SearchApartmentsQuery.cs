namespace Bookify.Application.Abstractions.Apartments.SearchApartments
{
    using Bookify.Application.Abstractions.Messaging;
    public sealed record SearchApartmentsQuery(
        DateOnly StartDate,
        DateOnly EndDate) : IQuery<IReadOnlyList<ApartmentResponse>>;
}