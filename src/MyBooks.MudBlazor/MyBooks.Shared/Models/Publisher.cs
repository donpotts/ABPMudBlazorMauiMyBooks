using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace MyBooks.Shared.Models;

public class Publisher
{
    [Key]
    public long? Id { get; set; }

    public string? Name { get; set; }

    public string? Country { get; set; }
}
