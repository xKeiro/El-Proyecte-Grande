using System.ComponentModel.DataAnnotations;

namespace backend.Dtos.Categories;

public abstract class CategoryWithName
{
    [Required]
    [StringLength(20, MinimumLength = 2)]
    public required string Name { get; set; }
}