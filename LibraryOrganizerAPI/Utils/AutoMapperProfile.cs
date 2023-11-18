using AutoMapper;
using Entity.DataTransferObjects;
using Entity.DataTransferObjects.Authors;
using Entity.DataTransferObjects.Categories;
using Entity.Model;

namespace LibraryOrganizerAPI.Utils
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Book Mapping Profile
            CreateMap<Book, BookDto>();
            CreateMap<BookDtoUpdate ,Book>().ReverseMap();
            CreateMap<BookDtoInsertion, Book>();

            //Category Mapping Profile
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDtoUpdate, Category>().ReverseMap();
            CreateMap<CategoryDtoInsertion, Category>();

            //Author Mapping Profile
            CreateMap<Author, AuthorDto>();
            CreateMap<AuthorDtoUpdate, Author>().ReverseMap();
            CreateMap<AuthorDtoInsertion, Author>();
        }

    }
}
