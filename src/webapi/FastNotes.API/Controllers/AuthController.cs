using FastNotes.Application.Dtos.AuthDtos;
using FastNotes.Application.Dtos.RefreshTokenDtos;
using FastNotes.Application.Features.Commands.ApplicationUserCommands.GoogleAuth;
using FastNotes.Application.Features.Commands.RefreshTokenCommands;
using FastNotes.Application.Features.Queries.NoteQueries.GetAllNotes;
using FastNotes.Domain.Entites;
using Google.Apis.Auth;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FastNotes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("google")]
        public async Task<IActionResult> GoogleAuth([FromBody] AuthRequestDto authRequestDto)
        {
            var query = new GoogleAuthCommand
            {
                IdToken = authRequestDto.IdToken,
            };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequestDto refreshTokenDto)
        {
            var query = new RenewRefreshTokenCommand
            {
                RefreshToken = refreshTokenDto.RefreshToken
            };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

    }
}
