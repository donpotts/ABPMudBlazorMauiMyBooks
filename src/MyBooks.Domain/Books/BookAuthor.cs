using System;
using Volo.Abp.Domain.Entities.Auditing;
using MyBooks.Authors;

namespace MyBooks.Books;

public class BookAuthor : AuditedEntity
{
	public int BookId { get; set; }

	public int AuthorId { get; set; }

	public Book? Book { get; set; }

	public Author? Author { get; set; }

	public BookAuthor()
	{
	}

	public override object[] GetKeys()
	{
		return [BookId, AuthorId];
	}
}
