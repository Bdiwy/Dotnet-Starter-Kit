using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Interfaces.Queries;
using Domain.Entities;
using InvoiceHub.Application.DTOs;

namespace Application.Services
{
    public class AuthService(IJwtTokenGenerator IJwtTokenGenerator , ICommonQueries<User> userRepo) : IAuthService
    {
        public Task<AuthResponseDto> LoginAsync(LoginRequestDto request)
        {
            IJwtTokenGenerator.GenerateToken(null, null);
            throw new NotImplementedException();
        }
    }
}