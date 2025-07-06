using FastNotes.Application.Params;
using FastNotes.Application.Wrappers;
using FastNotes.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNotes.Application.Interfaces.Repositories
{
    /// <summary>
    /// Uygulama notları için repository arayüzüdür. Bu arayüz, notlarla ilgili veri erişim işlemlerini tanımlar.
    /// </summary>
    public interface INoteRepository : IGenericRepository<Note>
    {
        /// <summary>
        /// Verilen kullanıcı kimliğine sahip tüm notları sayfalama yaparak asenkron olarak alır.
        /// </summary>
        /// <param name="requestParameter"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<PagedResponse<List<Note>>> GetAllByUserIdAsync(RequestParameter requestParameter, string userId);
        /// <summary>
        /// Verilen kimliğe ve kullanıcı kimliğine sahip notu asenkron olarak alır.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<Note?> GetByIdAndUserIdAsync(int id, string userId);
    }
}
