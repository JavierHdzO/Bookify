using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Apartments;

public sealed class Apartment(
    Guid id,
    string name, 
    string description,
    Address address,
    Money price,
    Money cleaningFee,
    List<Amenity> amenities) : Entity(id)
{
    public string Name { get; private set; } = name;
    public string Description { get; private set; } = description;
    public Address Address { get; private set; } = address;
    public Money Price { get; private set; } = price;
    public Money CleaningFee { get; private set; } = cleaningFee;
    public DateTime? LastBookedonUtc { get; private set; }
    public List<Amenity> Amenities { get; private set; } = amenities;
}
