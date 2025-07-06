using FastNotes.Application.Dtos.NoteDtos;
using FastNotes.Application.Features.Commands.NoteCommands.CreateNote;
using FastNotes.Application.Features.Commands.NoteCommands.DeleteNote;
using FastNotes.Application.Features.Commands.NoteCommands.UpdateNote;
using FastNotes.Application.Features.Queries.NoteQueries.GetAllNotes;
using FastNotes.Application.Features.Queries.NoteQueries.GetNotesById;
using FastNotes.Application.Params;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FastNotes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NotesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NotesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetNotes([FromQuery] RequestParameter parameters, string userId)
        {
            var query = new GetAllNotesQuery
            {
                Parameters = parameters,
                UserId = userId
            };
            var result = await _mediator.Send(query);
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> CreateNote([FromBody] NoteCreateDto noteCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var command = new CreateNoteCommand
            {
                Note = noteCreateDto
            };
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetNotes), new { id = result });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateNote([FromBody] NoteUpdateDto noteUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var command = new UpdateNoteCommand
            {
                Note = noteUpdateDto
            };
            var result = await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteNote([FromBody] NoteDeleteDto noteDeleteDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var command = new DeleteNoteCommand
            {
                Note = noteDeleteDto
            };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNoteById(int id, string userId)
        {
            var query = new GetNotesByIdQuery
            {
                Id = id,
                UserId = userId
            };
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
