using FastNotes.Application.Interfaces.Repositories;
using FastNotes.Application.Params;
using FastNotes.Application.Wrappers;
using FastNotes.Domain.Entites;
using FastNotes.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNotes.Infrastructure.Repositories
{
    /// <summary>
    /// Uygulama notları için repository sınıfıdır. Bu sınıf, notlarla ilgili veri erişim işlemlerini uygular.
    /// </summary>
    public class NoteRepository : GenericRepository<Note>, INoteRepository
    {
        private readonly ApplicationDBContext _context;
        public NoteRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PagedResponse<List<Note>>> GetAllByUserIdAsync(RequestParameter requestParameter, string userId)
        {
            var query = _context.Notes
            .Where(note => note.UserId == userId);

            var totalCount = await query.CountAsync();
            var values = await query
                .Skip((requestParameter.PageNumber - 1) * requestParameter.PageSize)
                .Take(requestParameter.PageSize)
                .ToListAsync();

            var hasNext = requestParameter.PageNumber * requestParameter.PageSize < totalCount;
            var hasPrevious = requestParameter.PageNumber > 1;

            return new PagedResponse<List<Note>>()
            {
                PageNumber = requestParameter.PageNumber,
                PageSize = requestParameter.PageSize,
                HasNext = hasNext,
                HasPrevious = hasPrevious,
                Value = values,
            };
        }

        public async Task<Note?> GetByIdAndUserIdAsync(int id, string userId)
        {
            return await _context.Notes
                .Where(note => note.Id == id && note.UserId == userId)
                .FirstOrDefaultAsync();
        }
    }
}
