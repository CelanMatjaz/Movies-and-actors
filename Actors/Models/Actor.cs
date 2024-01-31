using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ActorsService.Models;

[Table("actors")]
public class Actor
{
    [Key, Column("id", Order = 0), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required, Column("first_name")]
    public required string FirstName { get; set; }

    [Required, Column("last_name")]
    public required string LastName { get; set; }

    [Required, Column("born_date")]
    public DateOnly BornDate { get; set; }

    [Required, Column("list_of_movies")]
    public required string ListOfMovies { get; set; }

}

