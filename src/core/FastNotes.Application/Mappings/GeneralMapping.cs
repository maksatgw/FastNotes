using AutoMapper;
using FastNotes.Application.Dtos.NoteDtos;
using FastNotes.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNotes.Application.Mappings
{
    /// <summary>
    /// Automapper mapping işlemlerini içeren genel bir profil sınıfıdır.
    /// </summary>
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Note, NoteViewDto>().ReverseMap();
            CreateMap<Note, NoteCreateDto>().ReverseMap();
            CreateMap<Note, NoteUpdateDto>().ReverseMap();
        }
    }
}
