﻿using Bookify.Domain.Abstractions;
using Bookify.Domain.Shared;

namespace Bookify.Domain.Apartments;

public sealed class Apartment(
    Guid id,
    Name name,
    Description description,
    Address address,
    Money price,
    Money cleaningFee,
    List<Amenity> amenities) : Entity(id)
{
    public Name Name { get; private set; } = name;
    public Description Description { get; private set; } = description;
    public Address Address { get; private set; } = address;
    public Money Price { get; private set; } = price;
    public Money CleaningFee { get; private set; } = cleaningFee;
    public DateTime? LastBookedonUtc { get; internal set; }
    public List<Amenity> Amenities { get; private set; } = amenities;
}
