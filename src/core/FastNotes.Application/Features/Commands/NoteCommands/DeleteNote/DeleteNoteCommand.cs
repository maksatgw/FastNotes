using FastNotes.Application.Dtos.NoteDtos;
using FastNotes.Application.Exceptions;
using FastNotes.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNotes.Application.Features.Commands.NoteCommands.DeleteNote
{
    /// <summary>
    /// Not silme işlemi için kullanılan komut sınıfı.
    /// </summary>
    public class DeleteNoteCommand : IRequest
    {
        public NoteDeleteDto Note { get; set; }
        /// <summary>
        /// DeleteNoteCommand sınıfı, var olan bir notu silmek için kullanılır.
        /// </summary>
        public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand>
        {
            private readonly INoteRepository _noteRepository;

            public DeleteNoteCommandHandler(INoteRepository noteRepository)
            {
                _noteRepository = noteRepository;
            }

            /// <summary>
            /// DeleteNoteCommand işleyicisi, verilen notu siler.
            /// </summary>
            /// <param name="request"></param>
            /// <param name="cancellationToken"></param>
            /// <returns></returns>
            /// <exception cref="BusinessValidationException"></exception>
            /// <exception cref="NotFoundException"></exception>
            /// <exception cref="ForbiddenException"></exception>
            public async Task Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
            {
                if(request.Note == null)
                {
                    throw new BusinessValidationException("Not bilgisi boş olamaz.");
                }
                var note = await _noteRepository.GetByIdAsync(request.Note.Id);
                if (note == null)
                {
                    throw new NotFoundException("Not bulunamadı.");
                }
                if (note.UserId != request.Note.UserId)
                {
                    throw new ForbiddenException("Bu notu silme izniniz yok.");
                }
                await _noteRepository.DeleteAsync(note);
            }
        }
    }
}
