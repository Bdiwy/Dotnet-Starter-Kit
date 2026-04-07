namespace InvoiceHub.Application.DTOs
{
    public record AuthResponseDto(
        string Token, 
        string Username, 
        string Email, 
        bool IsOwner,
        Guid TenantId
    );
}