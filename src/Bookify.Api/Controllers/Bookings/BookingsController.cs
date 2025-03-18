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

    [HttpGet("Id")]
    public async Task<IActionResult> GetBooking(Guid Id, CancellationToken cancellationToken)
    {
        var query = new GetBookingQuery(Id);

        var result = await _sender.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> ReserveBooking(ReserveBookingRequest request)
    {
        var command = new ReserveBookingCommand(request.ApartmentId, request.UserId, request.StartDate, request.EndDate);

        var result = await _sender.Send(command);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }
        return CreatedAtAction(nameof(GetBooking), new { id = result.Value }, result.Value);
    }
}
