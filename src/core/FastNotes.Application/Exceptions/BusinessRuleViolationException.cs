using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNotes.Application.Exceptions
{
    /// <summary>
    /// İş kuralı ihlali durumularını temsil eden özel hata sınıfı.
    /// </summary>
    public class BusinessRuleViolationException : Exception
    {
        public BusinessRuleViolationException(string message) : base(message)
        {
        }
    }
}
