using Bookify.Application.Abstractions.Data;
using Bookify.Application.Abstractions.Messaging;
using Bookify.SharedKernel;
using Dapper;

namespace Bookify.Application.Bookings.GetBooking;

internal sealed class GetBookingQueryHandler : IQueryHandler<GetBookingQuery, BookingResponse?>
{

    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetBookingQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<BookingResponse?>> Handle(GetBookingQuery request, CancellationToken cancellationToken)
    {
        
        using var connection = _sqlConnectionFactory.CreateConnection();

        DynamicParameters parameters = new();
        parameters.Add("bookingId", request.BookingId);


        const string sql = """
            SELECT
               id AS Id,
               apartment_id AS ApartmentId,
               user_id AS UserId,
               status AS Status,
               price_for_period_amount AS PriceAmount,
               price_for_period_currency AS PriceCurrency,
               cleaning_fee_amount AS CleaningFeeAmount,
               cleaning_fee_currency AS CleaningFeeCurrency,
               amenities_up_charge_amount AS AmenitiesUpChargeAmount,
               amenities_up_charge_currency AS AmenitiesUpChargeCurrency,
               total_price_amount AS TotalPriceAmount,
               total_price_currency AS TotalPriceCurrency,
               duration_start AS DurationStart,
               duration_end AS DurationEnd,
               created_on_utc AS CreatedOnUtc
            FROM Bookings
            WHERE id = @bookingId
            """;

        var bookingResponse = await connection.QueryFirstOrDefaultAsync<BookingResponse>(
            sql: sql,
            param: parameters);


        return bookingResponse;
    }
}
