using System;
using Volo.Abp.Application.Dtos;

namespace MyBooks.Authors;

public class AuthorDto : AuditedEntityDto<int>
{
    public string? Name { get; set; }

    public DateTime BirthDate { get; set; }

    public string? ShortBio { get; set; }
}
