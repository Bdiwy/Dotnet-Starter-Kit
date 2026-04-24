using FluentValidation;
using InvoiceHub.Application.Requests.DTOs;
namespace InvoiceHub.Application.Requests;

public class LoginRequestValidator : AbstractValidator<LoginRequestDto> 
{
    public LoginRequestValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
    }
}