using System.ComponentModel.DataAnnotations;

namespace ElProyecteGrande.Models;

public class Ingredient: BaseModel
{
    [Required(ErrorMessage = "Name is required")]
    [StringLength(60, MinimumLength = 2)]
    public required string Name { get; set; }
}
