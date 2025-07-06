using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNotes.Application.Dtos.NoteDtos
{
    /// <summary>
    /// Not silme işlemi için kullanılan veri transfer nesnesi (DTO).
    /// </summary>
    public class NoteDeleteDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
    }
}
