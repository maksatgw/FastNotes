using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNotes.Application.Dtos.NoteDtos
{
    /// <summary>
    /// Not güncelleme için kullanılan veri transfer nesnesi (DTO).
    /// </summary>
    public class NoteUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string UserId { get; set; }
    }
}
