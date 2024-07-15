using System;
using Volo.Abp.Application.Dtos;

namespace MyBooks.Books;

public class CategoryLookupDto : EntityDto<int>
{
	public string? Name { get; set; }
}
