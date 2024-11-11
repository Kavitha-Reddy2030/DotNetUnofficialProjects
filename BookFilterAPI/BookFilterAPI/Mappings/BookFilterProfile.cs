using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookFilterAPI.Models.Domain;
using BookFilterAPI.Models.DTO;

namespace BookFilterAPI.Mappings
{
    public class BookFilterProfile:Profile
    {
        public BookFilterProfile()
        {
            CreateMap<Author, AuthorDTO>();
            CreateMap<BookSize, BookSizeDTO>();
            // Map between CreateBookDTO and Book (used for creating new books)
            CreateMap<CreateBookDTO, Book>();

            //CreateMap<Book, BookDTO>();

            // Map between Book and BookDTO (used for returning data to the client)
            CreateMap<Book, BookDTO>()
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author))
                .ForMember(dest => dest.BookSize, opt => opt.MapFrom(src => src.BookSize));

            CreateMap<BookFilterDTO, Book>() // or whatever your entity is
           .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title));

    }
    }
}
