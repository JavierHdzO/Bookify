using Bookify.Application.Bookings.GetBooking;
using Bookify.Application.Bookings.ReserveBooking;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Api.Controllers.Bookings;


[ApiController]
[Route("api/bookings")]
public class BookingsController : ControllerBase
{
    private readonly ISender _sender;

    public BookingsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookings(Guid id, CancellationToken cancellationToken) 
    {
        var query = new GetBookingQuery(id);

        var result = await _sender.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> ReserveBooking(
        ReserveBookingRequest request,
        CancellationToken cancellationToken) 
    {
    
        var command = new ReserveBookingCommand(
            ApartmentId: request.ApartmentId,
            UserId: request.UserId,
            StartDate: request.StartDate,
            EndDate: request.EndDate);


        var result = await _sender.Send(command, cancellationToken);

        if (result.IsFailure) 
        {
            return BadRequest(result.Error);
        }

        return CreatedAtAction(
            nameof(GetBookings),
            new { Id = result.Value },
            result.Value); 

    }

}
