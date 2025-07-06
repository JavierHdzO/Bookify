namespace Bookify.Application.Aparments.SearchApartments;

public sealed record ApartmentResponse
{
    public Guid Id { get; init; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Currency { get; set; } = string.Empty;
    public AddressResponse Address { get; set; } = default!;
}
