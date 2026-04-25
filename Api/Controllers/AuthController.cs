using InvoiceHub.Application.Requests.DTOs;
using InvoiceHub.Application.Handlers;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace InvoiceHub.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController(IMediator mediator)  : ControllerBase
{
    [HttpPost("login")]
    public async Task<ActionResult<AuthResponseDto>> Login([FromBody] LoginRequestDto request , CancellationToken ct)
    {
        var result = await mediator.Send(new LoginCommand(request), ct);
        return Ok(result); 
    }

    [HttpPost("register")]
    public async Task<ActionResult<AuthResponseDto>> Register([FromBody] RegisterRequestDto request , CancellationToken ct)
    {
        var result = await mediator.Send(new RegisterCommand(request), ct);
        return Ok(result); 
    }
}