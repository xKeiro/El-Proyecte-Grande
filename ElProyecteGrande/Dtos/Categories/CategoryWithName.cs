using System.ComponentModel.DataAnnotations;

namespace ElProyecteGrande.Dtos.Categories;

public abstract class CategoryWithName
{
    [Required]
    [StringLength(20, MinimumLength = 2)]
    public string Name { get; set; }
}
