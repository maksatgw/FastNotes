using AutoMapper;
using FastNotes.Application.Dtos.NoteDtos;
using FastNotes.Application.Exceptions;
using FastNotes.Application.Interfaces.Repositories;
using FastNotes.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNotes.Application.Features.Commands.NoteCommands.CreateNote
{
    /// <summary>
    /// Not oluşturma işlemi için kullanılan komut sınıfı.
    /// </summary>
    public class CreateNoteCommand : IRequest<int>
    {
        public NoteCreateDto Note { get; set; }

        /// <summary>
        /// CreateNoteCommand sınıfı, yeni bir not oluşturmak için kullanılır.
        /// </summary>
        public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, int>
        {
            private readonly INoteRepository _noteRepository;
            private readonly IMapper _mapper;
            public CreateNoteCommandHandler(INoteRepository noteRepository, IMapper mapper)
            {
                _noteRepository = noteRepository;
                _mapper = mapper;
            }
            /// <summary>
            /// CreateNoteCommand işleyicisi, yeni bir not oluşturur ve veritabanına kaydeder.
            /// </summary>
            /// <param name="request"></param>
            /// <param name="cancellationToken"></param>
            /// <returns></returns>
            /// <exception cref="BusinessValidationException"></exception>
            public async Task<int> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
            {

                if (request.Note == null)
                {
                    throw new BusinessValidationException("Not bilgisi boş olamaz.");
                }

                var note = _mapper.Map<Note>(request.Note);

                note.CreatedAt = DateTime.UtcNow;
                note.UpdatedAt = DateTime.UtcNow;

                await _noteRepository.AddAsync(note);

                return note.Id;
            }
        }
    }
}
