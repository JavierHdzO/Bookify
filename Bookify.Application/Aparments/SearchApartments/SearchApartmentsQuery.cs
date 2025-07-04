
using Bookify.Application.Abstractions.Messaging;

namespace Bookify.Application.Aparments.SearchApartments;

public sealed record SearchApartmentsQuery(
    DateOnly StartDate, 
    DateOnly EndDate) : IQuery<IReadOnlyList<ApartmentResponse>>;