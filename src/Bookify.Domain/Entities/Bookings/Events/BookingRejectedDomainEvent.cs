using Bookify.Domain.Entities.Abstractions;

namespace Bookify.Domain.Entities.Bookings.Events;

public record BookingRejectedDomainEvent(Guid BookingId) : IDomainEvent;
