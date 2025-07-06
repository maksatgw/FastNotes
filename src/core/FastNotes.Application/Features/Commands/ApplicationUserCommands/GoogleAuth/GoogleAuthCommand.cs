using FastNotes.Application.Dtos.AuthDtos;
using FastNotes.Application.Exceptions;
using FastNotes.Application.Interfaces.Repositories;
using FastNotes.Application.Interfaces.Services;
using FastNotes.Domain.Entites;
using Google.Apis.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FastNotes.Application.Features.Commands.ApplicationUserCommands.GoogleAuth
{
    /// <summary>
    /// Google ile kimlik doğrulama işlemi için kullanılan komut sınıfı.
    /// </summary>
    public class GoogleAuthCommand : IRequest<AuthResponseDto>
    {
        public string IdToken { get; set; }

        /// <summary>
        /// GoogleAuthCommand sınıfı, Google OAuth 2.0 ID Token'ı ile kimlik doğrulama işlemi için kullanılır.
        /// </summary>
        public class GoogleAuthCommandHandler : IRequestHandler<GoogleAuthCommand, AuthResponseDto>
        {
            private readonly UserManager<ApplicationUser> _userManager;
            private readonly ITokenService _tokenService;
            private readonly IConfiguration _configuration;
            public GoogleAuthCommandHandler(UserManager<ApplicationUser> userManager, IConfiguration configuration, ITokenService tokenService)
            {
                _userManager = userManager;
                _configuration = configuration;
                _tokenService = tokenService;
            }

            /// <summary>
            /// GoogleAuthCommand işleyicisi, ID Token'ı doğrular ve kullanıcıyı kimlik doğrular.
            /// </summary>
            /// <param name="request"></param>
            /// <param name="cancellationToken"></param>
            /// <returns></returns>
            /// <exception cref="BusinessValidationException"></exception>
            /// <exception cref="Exception"></exception>
            public async Task<AuthResponseDto> Handle(GoogleAuthCommand request, CancellationToken cancellationToken)
            {
                if (string.IsNullOrEmpty(request.IdToken))
                {
                    throw new BusinessValidationException("ID Token boş olamaz.");
                }
                var settings = new GoogleJsonWebSignature.ValidationSettings()
                {
                    Audience = new List<string> { _configuration["GoogleAuthSettings:ClientId"] }
                };
                var payload = await GoogleJsonWebSignature.ValidateAsync(request.IdToken, settings);
                var email = payload.Email;
                var name = $"{payload.GivenName} {payload.FamilyName}";
                var externalId = payload.Subject;
                var user = await _userManager.FindByEmailAsync(email);

                // Kullanıcı yoksa yeni kullanıcı oluştur
                if (user == null)
                {
                    user = new ApplicationUser
                    {
                        UserName = email,
                        Email = email,
                        EmailConfirmed = true,
                    };
                    var result = await _userManager.CreateAsync(user);
                    if (!result.Succeeded)
                    {
                        throw new Exception("Kullanıcı oluşturulamadı.");
                    }
                }

                var token = await _tokenService.GenerateJwtTokenAsync(user);
                var refreshToken = await _tokenService.GenerateAndSaveRefreshTokenAsync(user.Id);  

                return new AuthResponseDto 
                {
                    UserId = user.Id,
                    Token = token,
                    RefreshToken = refreshToken.Token,
                };
            }
        }
    }
}
