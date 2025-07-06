using FastNotes.Application.Dtos.RefreshTokenDtos;
using FastNotes.Application.Interfaces.Repositories;
using FastNotes.Application.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNotes.Application.Features.Commands.RefreshTokenCommands
{
    /// <summary>
    /// Yenileme token'ını yenilemek için kullanılan komut sınıfı.
    /// </summary>
    public class RenewRefreshTokenCommand : IRequest<RefreshTokenResponseDto>
    {
        public string RefreshToken { get; set; }

        /// <summary>
        /// Yenileme token'ını yenileme komutunun işleyici sınıfı.
        /// </summary>
        public class RenewRefreshTokenCommandHandler : IRequestHandler<RenewRefreshTokenCommand, RefreshTokenResponseDto>
        {
            private readonly ITokenService _tokenService;
            private readonly IRefreshTokenRepository _refreshTokenRepository;
            public RenewRefreshTokenCommandHandler(ITokenService tokenService, IRefreshTokenRepository refreshTokenRepository)
            {
                _tokenService = tokenService;
                _refreshTokenRepository = refreshTokenRepository;
            }
            /// <summary>
            /// Yenileme token'ını yenileme komutunu işleyen metot.
            /// </summary>
            /// <param name="request"></param>
            /// <param name="cancellationToken"></param>
            /// <returns></returns>
            /// <exception cref="Exception"></exception>

            public async Task<RefreshTokenResponseDto> Handle(RenewRefreshTokenCommand request, CancellationToken cancellationToken)
            {
                var existingRefreshToken = await _refreshTokenRepository.GetByTokenAsync(request.RefreshToken);

                if (existingRefreshToken == null || existingRefreshToken.Used || existingRefreshToken.Invalidated)
                {
                    throw new Exception("Invalid or expired refresh token.");
                }

                // Refresh token geçerli ise, yeni bir JWT token oluştur
                var newJwtToken = await _tokenService.GenerateJwtTokenAsync(existingRefreshToken.User);
                var newRefreshToken = await _tokenService.GenerateAndSaveRefreshTokenAsync(existingRefreshToken.UserId);

                // Eski refresh token'ı kullanılmış olarak işaretle
                existingRefreshToken.Used = true;
                existingRefreshToken.Invalidated = true;
                await _refreshTokenRepository.UpdateAsync(existingRefreshToken);

                return new RefreshTokenResponseDto
                {
                    UserId = existingRefreshToken.UserId,
                    Token = newJwtToken,
                    RefreshToken = newRefreshToken.Token
                };
            }
        }
    }
}
