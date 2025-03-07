using Bookify.Domain.Entities.Abstractions;
using Bookify.Domain.Entities.Apartments.ValueObjects;
using Bookify.Domain.Entities.Shared;

namespace Bookify.Domain.Entities.Apartments;

public sealed class Apartment : Entity
{
    public Name Name { get; private set; }
    public Description Description { get; private set; }
    public Address Address { get; private set; }
    public Money Price { get; private set; }
    public Money CleaningFee { get; private set; }
    public DateTime? LastBookedOnUtc { get; private set; }
    public List<Amenity> Amenities { get; private set; }

    public Apartment(
        Guid Id,
        Name name,
        Description description,
        Address address,
        Money price,
        Money cleaningFee,
        List<Amenity> amenities)
        : base(Id)
    {
        Name = name;
        Description = description;
        Address = address;
        Price = price;
        CleaningFee = cleaningFee;
        Amenities = amenities;
    }
}
