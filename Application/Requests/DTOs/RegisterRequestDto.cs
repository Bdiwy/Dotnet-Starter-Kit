namespace InvoiceHub.Application.Requests.DTOs;

public record RegisterRequestDto(
        string Email,
        string Username,
        string Password,
        string PhoneNumber
        );
