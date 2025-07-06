using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNotes.Application.Exceptions
{
    /// <summary>
    /// Verilen kaynağın bulunamadığı durumları temsil eden özel hata sınıfı.
    /// </summary>
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
