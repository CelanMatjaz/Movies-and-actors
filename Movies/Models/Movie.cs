using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesService;

[Table("movies")]
public class Movie
{
    [Key, Column("id", Order = 0), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required, Column("title")]
    public required string Title { get; set; }

    [Required, Column("year")]
    public required Int16 Year { get; set; }

    [Required, Column("description")]
    public required string Description { get; set; }

    [Required, Column("list_of_actors")]
    public required string ListOfActors { get; set; }

    [Required, Column("image_link")]
    public required string ImageLink { get; set; }

}

