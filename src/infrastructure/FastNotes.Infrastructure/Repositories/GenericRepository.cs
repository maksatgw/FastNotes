using FastNotes.Application.Interfaces.Repositories;
using FastNotes.Application.Params;
using FastNotes.Application.Wrappers;
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
    /// Temel generic repository sınıfıdır. Bu sınıf, temel CRUD işlemlerini uygular.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDBContext _context;

        public GenericRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<PagedResponse<List<T>>> GetAllAsync(RequestParameter requestParameter)
        {
            var values = await _context.Set<T>()
                .Skip((requestParameter.PageNumber - 1) * requestParameter.PageSize)
                .Take(requestParameter.PageSize)
                .ToListAsync();

            return new PagedResponse<List<T>>()
            {
                PageNumber = requestParameter.PageNumber,
                PageSize = requestParameter.PageSize,
                Value = values,
            };
        }

        public async Task<T> GetByIdAsync(int id)
        {
           return await _context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
