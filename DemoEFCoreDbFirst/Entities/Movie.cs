using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DemoEFCoreDbFirst.Entities;

[Table("movies")]
[Index("AuthorId", Name = "IX_movies_AuthorId")]
public partial class Movie
{
    [Key]
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public Guid? AuthorId { get; set; }

    [ForeignKey("AuthorId")]
    [InverseProperty("Movies")]
    public virtual Author? Author { get; set; }

    [ForeignKey("MoviesId")]
    [InverseProperty("Movies")]
    public virtual ICollection<Genre> Genres { get; set; } = new List<Genre>();
}
