using MyBooks.Books;
using MyBooks.Authors;
using MyBooks.Categories;
using AutoMapper;

namespace MyBooks.Web;

public class MyBooksWebAutoMapperProfile : Profile
{
    public MyBooksWebAutoMapperProfile()
    {
        CreateMap<BookDto, CreateUpdateBookDto>();
        CreateMap<AuthorDto, CreateUpdateAuthorDto>();
        CreateMap<CategoryDto, CreateUpdateCategoryDto>();
        CreateMap<Pages.Books.CreateModalModel.CreateBookViewModel, CreateUpdateBookDto>();
        CreateMap<BookDto, Pages.Books.EditModalModel.EditBookViewModel>();
        CreateMap<Pages.Books.EditModalModel.EditBookViewModel, CreateUpdateBookDto>();
    }
}
