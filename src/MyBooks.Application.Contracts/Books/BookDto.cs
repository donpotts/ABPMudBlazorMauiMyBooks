using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;
using MyBooks.Authors;
using MyBooks.Categories;

namespace MyBooks.Books;

public class BookDto : AuditedEntityDto<int>
{
    public string? Name { get; set; }

    public DateTime PublishDate { get; set; }

    public double Price { get; set; }

    public List<AuthorDto>? Authors { get; set; }

    public List<CategoryDto>? Categories { get; set; }
}
