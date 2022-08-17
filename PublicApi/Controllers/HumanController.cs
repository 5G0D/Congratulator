using System.Net;
using Contracts.Humans.CreateHuman;
using Contracts.Humans.DeleteHuman;
using Contracts.Humans.GetHumans;
using Contracts.Humans.UpdateHuman;
using Handlers.CreateHuman;
using Handlers.DeleteHuman;
using Handlers.GetHumans;
using Handlers.UpdateHuman;
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
    
    [HttpGet("createHuman")]
    [ProducesResponseType(typeof(CreateHumanResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> CreateHuman([FromQuery] CreateHumanRequest request, CancellationToken cancellation)
    {
        return Ok(await _mediator.Send(new CreateHumanCommand(request), cancellation));
    }
    
    [HttpGet("deleteHuman")]
    [ProducesResponseType(typeof(DeleteHumanResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> DeleteHuman([FromQuery] DeleteHumanRequest request, CancellationToken cancellation)
    {
        return Ok(await _mediator.Send(new DeleteHumanCommand(request), cancellation));
    }
    
    [HttpGet("updateHuman")]
    [ProducesResponseType(typeof(UpdateHumanResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> UpdateHuman([FromQuery] UpdateHumanRequest request, CancellationToken cancellation)
    {
        return Ok(await _mediator.Send(new UpdateHumanCommand(request), cancellation));
    }
}