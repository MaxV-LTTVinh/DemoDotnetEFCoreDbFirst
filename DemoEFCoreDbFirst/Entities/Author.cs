using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.FECore.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoEFCoreDbFirst.Entities;

[Table("authors")]
public partial class Author : BaseEntity<Guid>
{
    public string? Name { get; set; }

    public string? Dob { get; set; }

    [InverseProperty("Author")]
    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
