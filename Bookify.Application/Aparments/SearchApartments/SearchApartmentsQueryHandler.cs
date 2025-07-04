using Bookify.Application.Abstractions.Data;
using Bookify.Application.Abstractions.Messaging;
using Bookify.Domain.Bookings;
using Bookify.SharedKernel;
using Dapper;

namespace Bookify.Application.Aparments.SearchApartments;

internal sealed class SearchApartmentsQueryHandler 
    : IQueryHandler<SearchApartmentsQuery, IReadOnlyList<ApartmentResponse>>
{

    private static readonly int[] ActiveBookingStatuses = 
    [
        (int)BookingStatus.Reserved,
        (int)BookingStatus.Confirmed,
        (int)BookingStatus.Completed

    ]; 

    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public SearchApartmentsQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<IReadOnlyList<ApartmentResponse>>> Handle(SearchApartmentsQuery request, CancellationToken cancellationToken)
    {
        if (request.StartDate > request.EndDate)
        {
            return new List<ApartmentResponse>();
        }

        using var connection = _sqlConnectionFactory.CreateConnection();

        DynamicParameters paramenters = new();

        paramenters.Add("StartDate", request.StartDate);
        paramenters.Add("EndDate", request.EndDate);
        paramenters.Add("ActiveBookingStatuses", ActiveBookingStatuses);

        const string sql = @"
            SELECT 
                a.id as Id, 
                a.name as Name, 
                a.description as Description, 
                a.price_amount as Price, 
                a.price_currency as Currency, 
                a.address_contry as Country,
                a.address_state as State,
                a.address_zip_code as ZipCore,
                a.address_city as City,
                a.address_street as Street,
            FROM Apartments AS a
            WHERE NOT EXISTS (
                SELECT 1 FROM Bookings AS b
                WHERE b.ApartmentId = a.Id
                AND b.StartDate < @EndDate
                AND b.EndDate > @StartDate
                AND b.Status = ANY(@ActiveBookingStatuses)
            )";

        var apartments = await connection.QueryAsync<ApartmentResponse, AddressResponse, ApartmentResponse>(
            sql: sql,
            map: (aparment, address) => 
            {

                aparment.Address = address;

                return aparment;
            },
            param: paramenters,
            splitOn: "Country");


        return apartments.ToList();
    }
}
