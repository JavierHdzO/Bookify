﻿using Bookify.SharedKernel;

namespace Bookify.Domain.Bookings;

public static class BookingErrors
{

    public static Error NotFound =>
        new("Booking.NotFound", "The booking with the specific identifier was not found");
    public static Error Overlap =>
        new("Booking.Overlap", "The current booking is overlaping with an existing one");
    public static Error NotReserved =>
        new("Booking.NotReserved", "The booking is not pending");
    public static Error NotConfirmed =>
        new("Booking.NotConfirmed", "The booking is not confirmed");
    public static Error AlreadyStarted =>
        new("Booking.AlreadyStarted", "The booking has alreasy started");
}
