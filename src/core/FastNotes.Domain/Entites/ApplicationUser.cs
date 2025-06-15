using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNotes.Domain.Entites
{
    /// <summary>
    /// Uygulama kullanıcısı tablosunu temsil eden entity sınıfı.
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Note> Notes { get; set; }
        public ICollection<RefreshToken> RefreshTokens { get; set; }
    }
}
