using InvoiceHub.Application.DTOs;
namespace Application.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDto> LoginAsync(LoginRequestDto request);
    }
}