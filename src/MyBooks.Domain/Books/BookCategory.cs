using System;
using Volo.Abp.Domain.Entities.Auditing;
using MyBooks.Categories;

namespace MyBooks.Books;

public class BookCategory : AuditedEntity
{
	public int BookId { get; set; }

	public int CategoryId { get; set; }

	public Book? Book { get; set; }

	public Category? Category { get; set; }

	public BookCategory()
	{
	}

	public override object[] GetKeys()
	{
		return [BookId, CategoryId];
	}
}
