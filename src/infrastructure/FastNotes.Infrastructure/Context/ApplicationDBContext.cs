using FastNotes.Domain.Entites;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNotes.Infrastructure.Context
{
    /// <summary>
    /// ApplicationDBContext sınıfı, uygulamanın veritabanı bağlamını temsil eder.
    /// </summary>
    public class ApplicationDBContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "1",
                    UserName = "testuser",
                    Email = "testuser@example.com",
                    NormalizedUserName = "TESTUSER",
                    NormalizedEmail = "TESTUSER@EXAMPLE.COM",
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    ConcurrencyStamp = Guid.NewGuid().ToString("D"),
                    PasswordHash = "AQAAAAEAACcQAAAAE..." // Hashlenmiş şifre olmalı!
                }
            );

            builder.Entity<Note>().HasData(
            Enumerable.Range(1, 30).Select(i => new Note
                {
                    Id = i,
                    Title = $"Not {i}",
                    Content = $"Bu {i}. mockup notudur.",
                    UserId = "1"
                }).ToArray()
            );

            builder.Entity<RefreshToken>().HasData(
                new RefreshToken
                {
                    Id = 1,
                    Token = "mocktoken1",
                    Expiration = DateTime.UtcNow.AddDays(7),
                    UserId = "1"
                }
            );
        }
    }
}
