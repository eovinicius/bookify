namespace Bookify.Domain.Bookings;

public interface IBookingRepository
{
    Task<Booking?> GetById(Guid id, CancellationToken cancellationToken = default);

    void Add(Booking booking);
}