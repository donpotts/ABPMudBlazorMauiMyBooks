using MyBooks.Books;
using MyBooks.Authors;
using MyBooks.Categories;
using AutoMapper;

namespace MyBooks;

public class MyBooksApplicationAutoMapperProfile : Profile
{
    public MyBooksApplicationAutoMapperProfile()
    {
        CreateMap<Book, BookDto>();
        CreateMap<CreateUpdateBookDto, Book>();
        CreateMap<Author, AuthorDto>();
        CreateMap<CreateUpdateAuthorDto, Author>();
        CreateMap<Category, CategoryDto>();
        CreateMap<CreateUpdateCategoryDto, Category>();
        CreateMap<Author, MyBooks.Books.AuthorLookupDto>();
        CreateMap<Category, MyBooks.Books.CategoryLookupDto>();
    }
}
