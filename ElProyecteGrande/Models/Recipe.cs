using System.ComponentModel.DataAnnotations;

namespace ElProyecteGrande.Models;

public class Recipe: BaseModel
{
    [Required(ErrorMessage = "Name is required")]
    [StringLength(120, MinimumLength = 2)]
    public required string Name { get; set; }
}
