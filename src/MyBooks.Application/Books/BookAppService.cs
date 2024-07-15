using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using MyBooks.Authors;
using MyBooks.Categories;
using MyBooks.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.ChangeTracking;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace MyBooks.Books;

[Authorize(MyBooksPermissions.Books.Default)]
public class BookAppService :
    CrudAppService<
        Book, //The Book entity
        BookDto, //Used to show books
        int, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateBookDto>, //Used to create/update a book
    IBookAppService //implement the IBookAppService
{
    private readonly IRepository<Author, int> _authorRepository;
    private readonly IRepository<Category, int> _categoryRepository;

    public BookAppService(
        IRepository<Book, int> repository,
        IRepository<Author, int> authorRepository,
        IRepository<Category, int> categoryRepository)
        : base(repository)
    {
        _authorRepository = authorRepository;
        _categoryRepository = categoryRepository;
        GetPolicyName = MyBooksPermissions.Books.Default;
        GetListPolicyName = MyBooksPermissions.Books.Default;
        CreatePolicyName = MyBooksPermissions.Books.Create;
        UpdatePolicyName = MyBooksPermissions.Books.Edit;
        DeletePolicyName = MyBooksPermissions.Books.Delete;
    }

    [DisableEntityChangeTracking]
    public override async Task<BookDto> GetAsync(int id)
    {
        var book = await Repository.GetAsync(id) ?? throw new EntityNotFoundException(typeof(Book), id);

        var bookDto = ObjectMapper.Map<Book, BookDto>(book);
        bookDto.Authors = book.BookAuthors.Select(x => ObjectMapper.Map<Author, AuthorDto>(x.Author!)).ToList();
        bookDto.Categories = book.BookCategories.Select(x => ObjectMapper.Map<Category, CategoryDto>(x.Category!)).ToList();
        return bookDto;
    }

    [DisableEntityChangeTracking]
    public override async Task<PagedResultDto<BookDto>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        var books = await Repository.GetPagedListAsync(input.SkipCount, input.MaxResultCount, input.Sorting ?? nameof(Book.Id), true);

        var bookDtos = books.Select(x =>
        {
            var bookDto = ObjectMapper.Map<Book, BookDto>(x);
            bookDto.Authors = x.BookAuthors.Select(i => ObjectMapper.Map<Author, AuthorDto>(i.Author!)).ToList();
            bookDto.Categories = x.BookCategories.Select(i => ObjectMapper.Map<Category, CategoryDto>(i.Category!)).ToList();
            return bookDto;
        }).ToList();

        var totalCount = await Repository.GetCountAsync();

        return new PagedResultDto<BookDto>(
            totalCount,
            bookDtos
        );
    }

    public override async Task<BookDto> CreateAsync(CreateUpdateBookDto input)
    {
        var book = ObjectMapper.Map<CreateUpdateBookDto, Book>(input);
        book.BookAuthors = input.AuthorIds.Select(x => new BookAuthor() { AuthorId = x }).ToList();
        book.BookCategories = input.CategoryIds.Select(x => new BookCategory() { CategoryId = x }).ToList();

        await Repository.InsertAsync(book, true);

        using (Repository.DisableTracking())
        {
            book = await Repository.GetAsync(book.Id);
            var bookDto = ObjectMapper.Map<Book, BookDto>(book);
            bookDto.Authors = book.BookAuthors.Select(x => ObjectMapper.Map<Author, AuthorDto>(x.Author!)).ToList();
            bookDto.Categories = book.BookCategories.Select(x => ObjectMapper.Map<Category, CategoryDto>(x.Category!)).ToList();
            return bookDto;
        }
    }

    public override async Task<BookDto> UpdateAsync(int id, CreateUpdateBookDto input)
    {
        var book = await Repository.GetAsync(id) ?? throw new EntityNotFoundException(typeof(Book), id);

        ObjectMapper.Map(input, book);
        book.BookAuthors = input.AuthorIds.Select(x => new BookAuthor() { AuthorId = x }).ToList();
        book.BookCategories = input.CategoryIds.Select(x => new BookCategory() { CategoryId = x }).ToList();

        await Repository.UpdateAsync(book, true);

        using (Repository.DisableTracking())
        {
            book = await Repository.GetAsync(book.Id);
            var bookDto = ObjectMapper.Map<Book, BookDto>(book);
            bookDto.Authors = book.BookAuthors.Select(x => ObjectMapper.Map<Author, AuthorDto>(x.Author!)).ToList();
            bookDto.Categories = book.BookCategories.Select(x => ObjectMapper.Map<Category, CategoryDto>(x.Category!)).ToList();
            return bookDto;
        }
    }

    [DisableEntityChangeTracking]
    public async Task<ListResultDto<AuthorLookupDto>> GetAuthorLookupAsync()
    {
        var authors = await _authorRepository.GetListAsync();

        return new ListResultDto<AuthorLookupDto>(
            ObjectMapper.Map<List<Author>, List<AuthorLookupDto>>(authors)
        );
    }

    [DisableEntityChangeTracking]
    public async Task<ListResultDto<CategoryLookupDto>> GetCategoryLookupAsync()
    {
        var categories = await _categoryRepository.GetListAsync();

        return new ListResultDto<CategoryLookupDto>(
            ObjectMapper.Map<List<Category>, List<CategoryLookupDto>>(categories)
        );
    }
}
