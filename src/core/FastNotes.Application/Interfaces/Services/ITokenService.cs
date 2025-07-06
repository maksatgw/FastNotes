using FastNotes.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNotes.Application.Interfaces.Services
{
    /// <summary>
    /// Uygulama token işlemlerini yöneten servis arayüzü.
    /// </summary>
    public interface ITokenService
    {
        /// <summary>
        /// Kullanıcı için JWT token oluşturur.
        /// </summary>
        /// <param name="user"></param>
        /// <returns>JWT Token</returns>
        Task<string> GenerateJwtTokenAsync(ApplicationUser user);
        /// <summary>
        /// Kullanıcı için yenileme token oluşturur ve veritabanına kaydeder.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>RefreshToken tipinde yenileme token nesnesi </returns>
        Task<RefreshToken> GenerateAndSaveRefreshTokenAsync(string userId);

    }
}
