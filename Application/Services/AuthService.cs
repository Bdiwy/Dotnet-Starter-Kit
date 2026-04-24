using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Interfaces.Queries;
using Domain.Entities;
using InvoiceHub.Application.Requests;
using InvoiceHub.Application.Requests.DTOs;
using Microsoft.AspNetCore.Identity;

namespace Application.Services;
public class AuthService(IJwtTokenGenerator IJwtTokenGenerator , ICommonQueries<User> userRepo , ICommonQueries<Role> roleRepo , ICommonCommands<User> userCommandsRepo) : IAuthService
{
        public async Task<AuthResponseDto> LoginAsync(LoginRequestDto request)
        {
            User? user = await userRepo.FetchFirstAsync(u => u.Email == request.Email);
            
            if(user is null || !user.VerifyPassword(request.Password))
                return AuthResponseDto.Failure("Invalid email or password.");
            
            return AuthResponseDto.SuccessLogin(IJwtTokenGenerator.GenerateToken(user!), user!);
        }

        public async Task<AuthResponseDto> RegisterAsync(RegisterRequestDto request)
        {
            User? existingUser = await userRepo.FetchFirstAsync(u => u.Email == request.Email);
            
            if(existingUser is not null)
                return new AuthResponseDto (IsSuccess: false, Message: "Email already in use.");
            
            var OwnerRole = await roleRepo.FetchFirstAsync(u => u.Name == Role.COFOUNDERS.OWNER.ToString());
            var newUser = new User
            {
                Username = request.Username,
                Email = request.Email,
                IsOwner = true,
                PhoneNumber = request.PhoneNumber,
                RoleId = Guid.NewGuid(),
                Role = OwnerRole is not null ? OwnerRole : new Role {Name = Role.COFOUNDERS.OWNER.ToString()} ,
            };

            newUser.Password = new PasswordHasher<User>().HashPassword(newUser, request.Password);
            
            await userCommandsRepo.SaveMeAsync(newUser);
            return AuthResponseDto.SuccessRegister();
        }
}

public static class AuthServiceExtensions
{
    public static bool VerifyPassword(this User user, string password)
    {
        return new PasswordHasher<User>().VerifyHashedPassword(user, user.Password, password) 
                == PasswordVerificationResult.Success;
    }
}
