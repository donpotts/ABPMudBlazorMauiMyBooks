using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace MyBooks.Authors;

public class Author : AuditedAggregateRoot<int>
{
    public string? Name { get; set; }

    public DateTime BirthDate { get; set; }

    public string? ShortBio { get; set; }
}
