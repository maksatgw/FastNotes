using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNotes.Application.Dtos.RefreshTokenDtos
{
    /// <summary>
    /// Yeni bir erişim token'ı almak için kullanılan refresh token isteği DTO'su.
    /// </summary>
    public class RefreshTokenRequestDto
    {
        public string RefreshToken { get; set; }
    }
}
