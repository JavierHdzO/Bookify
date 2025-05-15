namespace Bookify.Application.Apartments.SearchApartments;

public record AddressResponse
{
    public required string Country { get; init; }
    public required string Status { get; init; }
    public required string ZipCode { get; init; }
    public required string City { get; init; }
    public required string Street { get; init; }

}
