using AutoMapper;
using FastNotes.Application.Dtos.NoteDtos;
using FastNotes.Application.Exceptions;
using FastNotes.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FastNotes.Application.Features.Commands.NoteCommands.UpdateNote
{
    /// <summary>
    /// Not güncelleme işlemi için kullanılan komut sınıfı.
    /// </summary>
    public class UpdateNoteCommand : IRequest<int>
    {
        public NoteUpdateDto Note { get; set; }

        /// <summary>
        /// UpdateNoteCommand sınıfı, var olan bir notu güncellemek için kullanılır.
        /// </summary>
        public class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommand, int>
        {
            private readonly INoteRepository _noteRepository;
            private readonly IMapper _mapper;
            public UpdateNoteCommandHandler(INoteRepository noteRepository, IMapper mapper)
            {
                _noteRepository = noteRepository;
                _mapper = mapper;
            }
            /// <summary>
            /// UpdateNoteCommand işleyicisi, verilen notu günceller ve veritabanına kaydeder.
            /// </summary>
            /// <param name="request"></param>
            /// <param name="cancellationToken"></param>
            /// <returns></returns>
            /// <exception cref="BusinessValidationException"></exception>
            /// <exception cref="NotFoundException"></exception>
            /// <exception cref="ForbiddenException"></exception>
            public async Task<int> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
            {
                if (request.Note == null)
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
                    throw new ForbiddenException("Bu notu güncelleme izniniz yok.");
                }
                _mapper.Map(request.Note, note);
                note.UpdatedAt = DateTime.UtcNow;
                await _noteRepository.UpdateAsync(note);
                return note.Id;
            }
        }
    }
}
