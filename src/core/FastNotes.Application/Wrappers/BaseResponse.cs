using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNotes.Application.Wrappers
{
    /// <summary>
    /// Uygulamadaki tüm dönüşler için temel bir yanıt sınıfıdır.
    /// </summary>
    public class BaseResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
