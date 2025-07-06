using FastNotes.Application.Interfaces.Repositories;
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
    /// RefreshTokenRepository sınıfı, yenileme token'ları için veri erişim işlemlerini uygular.
    /// </summary>
    public class RefreshTokenRepository : GenericRepository<RefreshToken>, IRefreshTokenRepository
    {
        private readonly ApplicationDBContext _context;
        public RefreshTokenRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<RefreshToken> GetByTokenAsync(string token)
        {
            return await _context.RefreshTokens.Include(x=>x.User).FirstOrDefaultAsync(x=>x.Token == token);
        }
    }
}
