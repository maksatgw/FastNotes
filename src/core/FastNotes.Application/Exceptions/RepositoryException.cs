using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNotes.Application.Exceptions
{
    /// <summary>
    /// Veri erişim katmanı ile ilgili hataları temsil eden özel hata sınıfı.
    /// </summary>
    public class RepositoryException : Exception
    {
        public RepositoryException(string? message) : base(message)
        {
        }
    }
}
