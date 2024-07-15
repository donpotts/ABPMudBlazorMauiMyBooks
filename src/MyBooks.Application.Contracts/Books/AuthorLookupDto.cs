using System;
using Volo.Abp.Application.Dtos;

namespace MyBooks.Books;

public class AuthorLookupDto : EntityDto<int>
{
	public string? Name { get; set; }
}
