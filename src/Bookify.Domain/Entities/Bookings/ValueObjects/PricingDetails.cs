using Bookify.Domain.Entities.Shared;

namespace Bookify.Domain.Entities.Bookings.ValueObjects;

public record PricingDetails(
    Money PriceForPeriod,
    Money CleaningFee,
    Money AmenitiesUpcharge,
    Money TotalPrice);
