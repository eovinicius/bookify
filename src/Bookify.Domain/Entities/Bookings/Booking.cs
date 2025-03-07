using Bookify.Domain.Entities.Abstractions;
using Bookify.Domain.Entities.Apartments;
using Bookify.Domain.Entities.Bookings.Events;
using Bookify.Domain.Entities.Bookings.ValueObjects;
using Bookify.Domain.Entities.Shared;

namespace Bookify.Domain.Entities.Bookings;

public sealed class Booking : Entity
{
    public Guid ApartmentId { get; private set; }
    public Guid UserId { get; private set; }
    public DateRange Duration { get; private set; }
    public Money PriceForPeriod { get; private set; }
    public Money CleaningFee { get; private set; }
    public Money AmenitiesUpCharge { get; private set; }
    public Money TotalPrice { get; private set; }
    public BookingStatus Status { get; private set; }
    public DateTime CreatedOnUtc { get; private set; }
    public DateTime? ConfirmedOnUtc { get; private set; }
    public DateTime? RejectedOnUtc { get; private set; }
    public DateTime? CompletedOnUtc { get; private set; }
    public DateTime? CancelledOnUtc { get; private set; }

    private Booking(
        Guid id,
        Guid apartmentId,
        Guid userId,
        DateRange duration,
        Money priceForPeriod,
        Money cleaningFee,
        Money amenitiesUpCharge,
        Money totalPrice,
        BookingStatus status,
        DateTime createdOnUtc)
            : base(id)
    {
        ApartmentId = apartmentId;
        UserId = userId;
        Duration = duration;
        PriceForPeriod = priceForPeriod;
        CleaningFee = cleaningFee;
        AmenitiesUpCharge = amenitiesUpCharge;
        TotalPrice = totalPrice;
        Status = status;
        CreatedOnUtc = createdOnUtc;
    }

    public static Booking Reverse(
        Apartment apartment,
        Guid userId,
        DateRange duration,
        DateTime utcNow,
        PricingService pricingService)
    {

        var pricingDetails = pricingService.CalculatePrice(apartment, duration);

        var booking = new Booking(
            Guid.NewGuid(),
            apartment.Id,
            userId,
            duration,
            pricingDetails.PriceForPeriod,
            pricingDetails.CleaningFee,
            pricingDetails.AmenitiesUpcharge,
            pricingDetails.TotalPrice,
            BookingStatus.Reserved,
            utcNow);

        booking.Raise(new BookingReservedDomainEvent(booking.Id));

        apartment.LastBookedOnUtc = utcNow;

        return booking;
    }
}
