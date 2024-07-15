using System;
using System.Collections.Generic;

namespace MyBooks.Books;

public class CreateUpdateBookDto
{
    public string? Name { get; set; }

    public DateTime PublishDate { get; set; }

    public double Price { get; set; }

    public List<int> AuthorIds { get; set; } = [];

    public List<int> CategoryIds { get; set; } = [];
}
