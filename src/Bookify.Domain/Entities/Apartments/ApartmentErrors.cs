using Bookify.Domain.Entities.Abstractions;

namespace Bookify.Domain.Entities.Apartments;

public static class ApartmentErrors
{
    public static Error NotFound = new(
        "Apartment.NotFound",
        "The apartment with the specified identifier was not found");
}