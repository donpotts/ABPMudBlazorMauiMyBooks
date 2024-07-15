using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace MyBooks.Books;

public class Book : AuditedAggregateRoot<int>
{
    public string? Name { get; set; }

    public DateTime PublishDate { get; set; }

    public double Price { get; set; }

    public ICollection<BookAuthor> BookAuthors { get; set; } = [];

    public ICollection<BookCategory> BookCategories { get; set; } = [];
}
