using FastNotes.Application.Dtos.AuthDtos;
using FastNotes.Application.Interfaces.Repositories;
using FastNotes.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNotes.Application.Features.Commands.RefreshTokenCommands
{
    /// <summary>
    /// Yenileme token'ı oluşturmak için kullanılan komut sınıfı.
    /// </summary>
    public class CreateRefreshTokenCommand : IRequest<AuthResponseDto>
    {
        public string UserId { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }

        /// <summary>
        /// Yenileme token'ı oluşturma komutunun işleyici sınıfı.
        /// </summary>
        public class CreateRefreshTokenCommandHandler : IRequestHandler<CreateRefreshTokenCommand, AuthResponseDto>
        {
            private readonly IRefreshTokenRepository _refreshTokenRepository;

            public CreateRefreshTokenCommandHandler(IRefreshTokenRepository refreshTokenRepository)
            {
                _refreshTokenRepository = refreshTokenRepository;
            }

            /// <summary>
            /// Yenileme token'ı oluşturma komutunu işleyen metot.
            /// </summary>
            /// <param name="request"></param>
            /// <param name="cancellationToken"></param>
            /// <returns></returns>
            public async Task<AuthResponseDto> Handle(CreateRefreshTokenCommand request, CancellationToken cancellationToken)
            {
                var refreshToken = new RefreshToken
                {
                    UserId = request.UserId,
                    Token = request.Token,
                    Expiration = request.Expiration,
                    Used = false,
                    Invalidated = false
                };

                await _refreshTokenRepository.AddAsync(refreshToken);

                return new AuthResponseDto();
            }
        }

    }
}
