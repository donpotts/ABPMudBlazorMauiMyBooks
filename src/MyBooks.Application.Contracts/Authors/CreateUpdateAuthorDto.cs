using System;

namespace MyBooks.Authors;

public class CreateUpdateAuthorDto
{
    public string? Name { get; set; }

    public DateTime BirthDate { get; set; }

    public string? ShortBio { get; set; }
}
