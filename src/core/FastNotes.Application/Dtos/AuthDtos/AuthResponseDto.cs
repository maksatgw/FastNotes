using FastNotes.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNotes.Application.Dtos.AuthDtos
{
    /// <summary>
    /// Kimlik doğrulama yanıtı için kullanılan veri transfer nesnesi (DTO).
    /// </summary>
    public class AuthResponseDto 
    {
        public string UserId { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
