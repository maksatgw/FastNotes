using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNotes.Application.Wrappers
{
    /// <summary>
    /// Temel bir hizmet yanıt sınıfıdır.
    /// </summary>
    public class ServiceResponse<T>
    {
        // Tip
        public T Value { get; set; }

        public ServiceResponse()
        {

        }

        public ServiceResponse(T value)
        {
            Value = value;
        }


    }
}
