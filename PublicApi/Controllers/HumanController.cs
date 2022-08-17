using System.Net;
using Contracts.Humans.GetHumans;
using Handlers.GetHumans;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Congratulator.Controllers;

[Route("api/humans")]
[Produces("application/json")]
[ApiController]
public class HumansController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public HumansController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("getHumans")]
    [ProducesResponseType(typeof(GetHumansResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetHumans([FromQuery] GetHumansRequest request, CancellationToken cancellation)
    {
        return Ok(await _mediator.Send(new GetHumansQuery(request), cancellation));
    }
}