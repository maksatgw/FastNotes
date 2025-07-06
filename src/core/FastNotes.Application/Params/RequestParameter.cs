using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNotes.Application.Params
{
    /// <summary>
    /// Gelen sayfalama isteklerinin parametrelerini temsil eden sınıf.
    /// </summary>
    public class RequestParameter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public RequestParameter()
        {
            PageNumber = 1; // Varsayılan sayfa numarası
            PageSize = 10; // Varsayılan sayfa boyutu
        }

        public RequestParameter(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
