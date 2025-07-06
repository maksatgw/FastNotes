using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNotes.Domain.Entites
{
    /// <summary>
    /// Uygulama yenileme token'ları tablosunu temsil eden entity sınıfı.
    /// </summary>
    public class RefreshToken
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public bool Used { get; set; }
        public bool Invalidated { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
