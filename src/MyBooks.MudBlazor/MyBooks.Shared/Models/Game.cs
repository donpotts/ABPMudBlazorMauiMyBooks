using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace MyBooks.Shared.Models;

public class Game
{
    [Key]
    public long? Id { get; set; }

    public string? Name { get; set; }

    public string? Developer { get; set; }

    public string? PublisherName { get; set; }

    public long? PublisherId { get; set; }
    
    public Publisher? Publisher { get; set; }
}
