using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyBooks.Categories;
using MyBooks.Authors;
using MyBooks.Books;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace MyBooks;

public class MyBooksDataSeederContributor
    : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Category, int> _categoryRepository;
    private readonly IRepository<Author, int> _authorRepository;
    private readonly IRepository<Book, int> _bookRepository;

    public MyBooksDataSeederContributor(
        IRepository<Category, int> categoryRepository,
        IRepository<Author, int> authorRepository,
        IRepository<Book, int> bookRepository)
    {
        _categoryRepository = categoryRepository;
        _authorRepository = authorRepository;
        _bookRepository = bookRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        Dictionary<int, Category> categories = [];

        if (await _categoryRepository.GetCountAsync() <= 0)
        {
            categories[1] = await _categoryRepository.InsertAsync(
                new Category
                {
                    Name = "C#",
                },
                autoSave: true
            );
            categories[2] = await _categoryRepository.InsertAsync(
                new Category
                {
                    Name = "Web Programming",
                },
                autoSave: true
            );
            categories[3] = await _categoryRepository.InsertAsync(
                new Category
                {
                    Name = "Database",
                },
                autoSave: true
            );
            categories[4] = await _categoryRepository.InsertAsync(
                new Category
                {
                    Name = "Graphic Design",
                },
                autoSave: true
            );
        }

        Dictionary<int, Author> authors = [];

        if (await _authorRepository.GetCountAsync() <= 0)
        {
            authors[1] = await _authorRepository.InsertAsync(
                new Author
                {
                    Name = "The Author",
                    BirthDate = new DateTime(2000, 1, 1, 0, 0, 0),
                    ShortBio = "Computer programmer and author of many papers and books.",
                },
                autoSave: true
            );
            authors[2] = await _authorRepository.InsertAsync(
                new Author
                {
                    Name = "My Author",
                    BirthDate = new DateTime(2000, 1, 2, 0, 0, 0),
                    ShortBio = "Computer programmer and author of many papers and books.",
                },
                autoSave: true
            );
            authors[3] = await _authorRepository.InsertAsync(
                new Author
                {
                    Name = "Your Author",
                    BirthDate = new DateTime(2000, 1, 3, 0, 0, 0),
                    ShortBio = "Computer programmer and author of many papers and books.",
                },
                autoSave: true
            );
        }

        Dictionary<int, Book> books = [];

        if (await _bookRepository.GetCountAsync() <= 0)
        {
            books[1] = await _bookRepository.InsertAsync(
                new Book
                {
                    Name = "Your Book Name",
                    PublishDate = new DateTime(2024, 7, 10, 0, 0, 0),
                    Price = 15.1,
                    BookAuthors = [new BookAuthor { Author = authors[1] }, new BookAuthor { Author = authors[2] }],
                    BookCategories = [new BookCategory { Category = categories[1] }, new BookCategory { Category = categories[2] }],
                },
                autoSave: true
            );
            books[2] = await _bookRepository.InsertAsync(
                new Book
                {
                    Name = "My Book Name",
                    PublishDate = new DateTime(2024, 7, 10, 0, 0, 0),
                    Price = 15.5,
                    BookAuthors = [new BookAuthor { Author = authors[1] }],
                    BookCategories = [new BookCategory { Category = categories[1] }],
                },
                autoSave: true
            );
            books[3] = await _bookRepository.InsertAsync(
                new Book
                {
                    Name = "Her Book Name",
                    PublishDate = new DateTime(2024, 7, 10, 0, 0, 0),
                    Price = 15.8,
                    BookAuthors = [new BookAuthor { Author = authors[1] }, new BookAuthor { Author = authors[2] }, new BookAuthor { Author = authors[3] }],
                    BookCategories = [new BookCategory { Category = categories[1] }, new BookCategory { Category = categories[2] }, new BookCategory { Category = categories[3] }],
                },
                autoSave: true
            );
            books[4] = await _bookRepository.InsertAsync(
                new Book
                {
                    Name = "His Book Name",
                    PublishDate = new DateTime(2024, 7, 10, 0, 0, 0),
                    Price = 159.9,
                    BookAuthors = [new BookAuthor { Author = authors[2] }, new BookAuthor { Author = authors[3] }],
                    BookCategories = [new BookCategory { Category = categories[2] }, new BookCategory { Category = categories[3] }],
                },
                autoSave: true
            );
        }
    }
}
