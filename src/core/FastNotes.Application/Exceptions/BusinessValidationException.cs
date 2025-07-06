using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNotes.Application.Exceptions
{
    /// <summary>
    /// İş kurallarına aykırı olan validasyon hatalarını temsil eden özel hata sınıfı.
    /// </summary>
    public class BusinessValidationException : Exception
    {
        public BusinessValidationException() : base("Validasyon Hatası.")
        {
        }
        public BusinessValidationException(string message) : base(message)
        {
        }
        public BusinessValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }
        public BusinessValidationException(IEnumerable<string> errors)
            : base("Validation errors occurred: " + string.Join(", ", errors))
        {
        }
    }
}
