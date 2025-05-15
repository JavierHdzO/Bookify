using FluentValidation;

namespace Bookify.Application.Bookings.ReserveBooking;

internal class ReserveBookingCommandValidator : AbstractValidator<ReserveBookingCommand>
{
    public ReserveBookingCommandValidator() 
    {
        RuleFor(r => r.UserId).NotEmpty();

        RuleFor(r => r.ApartmentId).NotEmpty();

        RuleFor(r => r.StartDate).LessThan(r => r.EndDate);
    }
}
