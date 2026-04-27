using InvoiceHub.Application.Requests.DTOs;
using InvoiceHub.Application.Handlers;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace InvoiceHub.Api.Controllers;

[ApiController]
[Route("api/clients")]
public class ClientController(IMediator mediator)  : ControllerBase
{
    // [Authorize]
    // [HttpPost("create-client")]
    // public async Task<ActionResult<ClientResponseDto>> CreateClient([FromBody] CreateClientRequestDto request , CancellationToken ct)
    // {
    //     var result = await mediator.Send(new CreateClientCommand(request), ct);
    //     return Ok(result); 
    // }

    // [Authorize]
    // [HttpGet("get-client-by-id")]
    // public async Task<ActionResult<Client>> GetClientById([FromQuery] Guid clientId , CancellationToken ct)
    // {
    //     var result = await mediator.Send(new GetClientByIdQuery(clientId), ct);
    //     return Ok(result); 
    // }

    // [Authorize]
    // [HttpGet("get-all-clients")]
    // public async Task<ActionResult<List<Client>>> GetAll([FromQuery] Guid tenantId , CancellationToken ct)
    // {
    //     var result = await mediator.Send(new GetAllClientsQuery(tenantId), ct);
    //     return Ok(result); 
    // }

    [Authorize]
    [HttpGet("authorize-test")]
    public async Task<ActionResult> GetAll(CancellationToken ct)
    {
        return Ok(); 
    }

    [HttpGet("non-authorize-test")]
    public async Task<ActionResult>Test(CancellationToken ct)
    {
        return Ok(); 

    }

    
    
}