using AutoMapper;
using FastNotes.Application.Dtos.NoteDtos;
using FastNotes.Application.Interfaces.Repositories;
using FastNotes.Application.Params;
using FastNotes.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNotes.Application.Features.Queries.NoteQueries.GetAllNotes
{
    /// <summary>
    /// Tüm notları almak için kullanılan sorgu sınıfı.
    /// </summary>
    public class GetAllNotesQuery : IRequest<PagedResponse<List<NoteViewDto>>>
    {
        public RequestParameter Parameters { get; set; }
        public string UserId { get; set; }

        /// <summary>
        /// Sorgu sınıfının yapıcı metodu.
        /// </summary>
        public class GetAllNotesQueryHandler : IRequestHandler<GetAllNotesQuery, PagedResponse<List<NoteViewDto>>>
        {
            private readonly INoteRepository _noteRepository;
            private readonly IMapper _mapper;

            public GetAllNotesQueryHandler(INoteRepository noteRepository, IMapper mapper)
            {
                _noteRepository = noteRepository;
                _mapper = mapper;
            }

            /// <summary>
            /// Tüm notları almak için sorgu işleyici metodu.
            /// </summary>
            /// <param name="request"></param>
            /// <param name="cancellationToken"></param>
            /// <returns></returns>
            public async Task<PagedResponse<List<NoteViewDto>>> Handle(GetAllNotesQuery request, CancellationToken cancellationToken)
            {
                var notes = await _noteRepository.GetAllByUserIdAsync(request.Parameters, request.UserId);

                var notesDto = _mapper.Map<List<NoteViewDto>>(notes.Value);

                return new PagedResponse<List<NoteViewDto>>(){
                        PageNumber = notes.PageNumber,
                        PageSize = notes.PageSize,
                        HasNext = notes.HasNext,
                        HasPrevious = notes.HasPrevious,
                        Value = notesDto
                    };
            }
        }
    }
}
