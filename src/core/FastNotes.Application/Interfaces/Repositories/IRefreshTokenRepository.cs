using FastNotes.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNotes.Application.Interfaces.Repositories
{
    /// <summary>
    /// Uygulama yenileme token'ları için repository arayüzüdür. Bu arayüz, yenileme token'larıyla ilgili veri erişim işlemlerini tanımlar.
    /// </summary>
    public interface IRefreshTokenRepository : IGenericRepository<RefreshToken>
    {
        /// <summary>
        /// Verilen token değerine sahip yenileme token'ını asenkron olarak alır.
        /// </summary>
        /// <param name="token"></param>
        /// <returns>RefreshToken modeli</returns>
        Task<RefreshToken> GetByTokenAsync(string token);
    }
}
