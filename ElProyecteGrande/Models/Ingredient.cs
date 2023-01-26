using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ElProyecteGrande.Models;

[Index(nameof(Name), IsUnique = true)]
public class Ingredient : BaseModel
{
    [Required]
    [StringLength(60, MinimumLength = 2)]
    public string Name { get; set; }

    [Required]
    public string UnitOfMeasure { get; set; }
}
