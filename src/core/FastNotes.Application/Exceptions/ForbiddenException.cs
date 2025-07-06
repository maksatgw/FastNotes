using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNotes.Application.Exceptions
{
    /// <summary>
    /// Erişim yetkisi olmayan durumları temsil eden özel hata sınıfı.
    /// </summary>
    public class ForbiddenException : Exception
    {
        public ForbiddenException(string message) : base(message) { }
    }
}
