using Application.Interfaces;
using InvoiceHub.Application.Requests.DTOs;
using MediatR;
namespace InvoiceHub.Application.Handlers;

public record LoginCommand(LoginRequestDto RequestDto) : IRequest<AuthResponseDto>;
public class LoginRequestHandler(IAuthService authService) 
: IRequestHandler<LoginCommand, AuthResponseDto>
{
    public async Task<AuthResponseDto> Handle(LoginCommand request , CancellationToken ct)
    {
        var result = await authService.LoginAsync(request.RequestDto);
        return result; 
    }
    
}