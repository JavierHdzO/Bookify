﻿using Bookify.Domain.Abstractions;
using Bookify.Domain.Common;

namespace Bookify.Domain.Apartments;

public sealed class Apartment : Entity<Apartment>
{
    public Apartment(
        Guid id,
        Name name,
        Description description,
        Address address,
        Money price,
        Money cleaningFee,
        DateTime? lastBookedOnUtc,
        List<Amenity> amenities)
        : base(id)
    {
        Name = name;
        Description = description;
        Address = address;
        Price = price;
        CleaningFee = cleaningFee;
        LastBookedOnUtc = lastBookedOnUtc;
        Amenities = amenities;
    }

    private Apartment() 
    {
    }


    public Name Name { get; private set; }
    public Description Description { get; private set; }
    public Address Address { get; private set; }
    public Money Price { get; private set; }
    public Money CleaningFee { get; private set; }
    public DateTime? LastBookedOnUtc { get;  set; }
    public List<Amenity> Amenities { get; private set; } = [];
}
