using Bookify.Domain.Apartments;
using Bookify.Domain.Bookings.ValueObjects;

namespace Bookify.Domain.Bookings;

public interface IBookingRepository
{
    Task<Booking?> GetById(Guid id, CancellationToken cancellationToken = default);

    Task<bool> IsOverlapping(
        Apartment apartment,
        DateRange duration,
        CancellationToken cancellationToken = default);

    void Add(Booking booking);
}