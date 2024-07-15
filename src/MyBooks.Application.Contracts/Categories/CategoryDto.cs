using System;
using Volo.Abp.Application.Dtos;

namespace MyBooks.Categories;

public class CategoryDto : AuditedEntityDto<int>
{
    public string? Name { get; set; }
}
