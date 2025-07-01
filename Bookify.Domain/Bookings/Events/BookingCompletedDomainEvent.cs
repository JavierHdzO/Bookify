using Bookify.SharedKernel;

namespace Bookify.Domain.Bookings.Events;

public sealed record BookingCompletedDomainEvent(Guid BookingId) :IDomainEvent;
