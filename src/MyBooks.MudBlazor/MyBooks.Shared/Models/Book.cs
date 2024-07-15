using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace MyBooks.Shared.Models;

[DataContract]
public class Book
{
    [Key]
    [DataMember]
    public long? Id { get; set; }

    [DataMember]
    public string? Name { get; set; }

    [DataMember]
    public DateTime? PublishDate { get; set; }

    [DataMember]
    public decimal? Price { get; set; }

    [DataMember]
    public List<Author>? Authors { get; set; }

    [DataMember]
    public List<Category>? Categories { get; set; }

    [IgnoreDataMember]
    public List<long?>? AuthorIds { get; set; }

    [IgnoreDataMember]
    public List<long?>? CategoryIds { get; set; }
}
