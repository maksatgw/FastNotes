using FastNotes.Application.Interfaces.Repositories;
using FastNotes.Application.Interfaces.Services;
using FastNotes.Domain.Entites;
using FastNotes.Infrastructure.Context;
using FastNotes.Infrastructure.Repositories;
using FastNotes.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNotes.Infrastructure.Extensions
{
    /// <summary>
    /// ServiceRegistration sınıfı, uygulama için gerekli servislerin DI konteynerine eklenmesini sağlar.
    /// </summary>
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDBContext>(options => options.UseInMemoryDatabase("ProductLearnAppDb"));

            services.AddTransient<INoteRepository, NoteRepository>();
            services.AddTransient<IRefreshTokenRepository, RefreshTokenRepository>();

            services.AddScoped<ITokenService, TokenService>();
        }
    }
}
