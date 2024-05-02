namespace Bookify.Application.Abstractions.Clock
{
    using System;

    public interface IDateTimeProvider
    {
        DateTime UtcNow { get; }
    }
}