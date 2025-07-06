using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNotes.Application.Wrappers
{
    /// <summary>
    /// Temel bir sayfalı yanıt sınıfıdır.
    /// </summary>
    public class PagedResponse<T> : ServiceResponse<T> 
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public bool HasNext { get; set; }
        public bool HasPrevious { get; set; }

        public PagedResponse(T value) : base(value)
        {
          
        }
        public PagedResponse(int pageNumber, int pageSize, bool hasNext, bool hasPrevious)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            HasNext = hasNext;
            HasPrevious = hasPrevious;
        }
        public PagedResponse()
        {
            PageNumber = 1;
            PageSize = 10;
        }
    }
}
