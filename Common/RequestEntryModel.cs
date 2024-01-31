using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonData;

[Table("request_entries")]
public class RequestCountEntry
{
    [Key, Column("id", Order = 0), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required, Column("service")]
    public required string Service { get; set; }

    [Required, Column("endpoint")]
    public required string Endpoint { get; set; }

    [Column("query_params")]
    public string? QueryParams { get; set; }

    [Column("body")]
    public string? Body { get; set; }

    [Required, Column("method")]
    public required string Method { get; set; }

    [Required, Column("timestamp")]
    public required DateTime Timestamp { get; set; }
}


