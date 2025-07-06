using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNotes.Application.Dtos.AuthDtos
{
    /// <summary>
    /// Kimlik doğrulama isteği için kullanılan veri transfer nesnesi (DTO).
    /// </summary>
    public class AuthRequestDto 
    {
        public string IdToken { get; set; }
    }
}
