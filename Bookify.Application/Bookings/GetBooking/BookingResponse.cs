namespace Bookify.Application.Bookings.GetBooking;

public sealed record BookingResponse
{
    public required Guid Id { get; init; }
    public required Guid UserId { get; init; }
    public required Guid AparmentId { get; init; }
    public required int Status { get; init; }
    public required decimal PriceAmount { get; init; }
    public required decimal PriceCurrency { get; init; }
    public required string CleaningFeeAmount { get; init; }
    public required string CleaningFeeCurrency { get; init; }
    public required decimal TotalPriceAmount { get; init; }
    public required string TotalPriceCurrency { get; init; }
    public required DateOnly DurationStart { get; init; }
    public required DateOnly DurationEnd { get; init; }
    public required DateOnly CreatedOnUtc { get; init; }
}
