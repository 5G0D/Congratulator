using System.Net;
using Contracts.Birthdays.GetBirthdays;
using Handlers.GetBirthdays;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Congratulator.Controllers;

[Route("api/birthdays")]
[Produces("application/json")]
[ApiController]
public class BirthdayController
{
    private readonly IMediator _mediator;
    
    public BirthdayController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("getBirthdays")]
    [ProducesResponseType(typeof(GetBirthdaysResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetBirthdays([FromQuery] GetBirthdaysRequest request, CancellationToken cancellation)
    {
        return Ok(await _mediator.Send(new GetBirthdaysQuery(request), cancellation));
    }
}