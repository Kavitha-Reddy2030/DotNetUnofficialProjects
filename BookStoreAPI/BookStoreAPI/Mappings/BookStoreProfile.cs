using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookStoreAPI.Models.Domain;
using BookStoreAPI.Models.DTO;

namespace BookStoreAPI.Mappings
{
    public class BookStoreProfile : Profile
    {

        public BookStoreProfile()
        {

            CreateMap<Author, AuthorDTO>();
            CreateMap<BookSize, BookSizeDTO>();
            CreateMap<CreateBookDTO, Book>();

            // Map between Book and BookDTO (used for returning data to the client)
            CreateMap<Book, BookDTO>()
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author))
                .ForMember(dest => dest.BookSize, opt => opt.MapFrom(src => src.BookSize));
        }
    }
}
