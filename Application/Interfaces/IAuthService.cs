using InvoiceHub.Application.Requests.DTOs;
using InvoiceHub.Application.Requests;
namespace Application.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDto> LoginAsync(LoginRequestDto request);
        Task<AuthResponseDto> RegisterAsync(RegisterRequestDto request);
    }
}