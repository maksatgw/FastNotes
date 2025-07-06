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

namespace FastNotes.Application.Features.Queries.NoteQueries.GetNotesById
{
    /// <summary>
    /// Notları ID'ye göre almak için kullanılan sorgu sınıfı.
    /// </summary>
    public class GetNotesByIdQuery : IRequest<NoteViewDto>
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        /// <summary>
        /// Sorgu sınıfının yapıcı metodu.
        /// </summary>
        public class GetNotesByIdQueryHandler : IRequestHandler<GetNotesByIdQuery, NoteViewDto>
        {
            private readonly INoteRepository _noteRepository;
            private readonly IMapper _mapper;
            public GetNotesByIdQueryHandler(INoteRepository noteRepository, IMapper mapper)
            {
                _noteRepository = noteRepository;
                _mapper = mapper;
            }
            /// <summary>
            /// Notları ID'ye göre almak için sorgu işleyici metodu.
            /// </summary>
            /// <param name="request"></param>
            /// <param name="cancellationToken"></param>
            /// <returns></returns>
            /// <exception cref="NotFoundException"></exception>
            public async Task<NoteViewDto> Handle(GetNotesByIdQuery request, CancellationToken cancellationToken)
            {
                var note = await _noteRepository.GetByIdAndUserIdAsync(request.Id, request.UserId);

                if (note == null)
                {
                    throw new NotFoundException($"{request.Id} göre not bulunamadı.");
                }
                return _mapper.Map<NoteViewDto>(note);
            }
        }
    }
}
