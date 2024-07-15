using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace MyBooks.Categories;

public class Category : AuditedAggregateRoot<int>
{
    public string? Name { get; set; }
}
