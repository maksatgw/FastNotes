using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastNotes.Application.Params;
using FastNotes.Application.Wrappers;

namespace FastNotes.Application.Interfaces.Repositories
{
    /// <summary>
    /// Temel generic repository arayüzüdür. Bu arayüz, temel CRUD işlemlerini tanımlar.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// Verilen kimliğe sahip bir varlığı asenkron olarak alır.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(int id);
        /// <summary>
        /// Verilen sayfalama parametrelerine göre tüm varlıkları sayfalama yaparak asenkron olarak alır.
        /// </summary>
        /// <param name="requestParameter"></param>
        /// <returns></returns>
        Task<PagedResponse<List<T>>> GetAllAsync(RequestParameter requestParameter);
        /// <summary>
        /// Verilen varlığı asenkron olarak ekler.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task AddAsync(T entity);
        /// <summary>
        /// Verilen varlığı asenkron olarak günceller.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task UpdateAsync(T entity);
        /// <summary>
        /// Verilen varlığı asenkron olarak siler.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task DeleteAsync(T entity);
    }
}
