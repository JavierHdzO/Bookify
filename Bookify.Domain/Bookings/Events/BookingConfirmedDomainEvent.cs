﻿using Bookify.SharedKernel;

namespace Bookify.Domain.Bookings.Events;

public sealed record BookingConfirmedDomainEvent(Guid BookingId) :IDomainEvent;
