using System.ComponentModel.DataAnnotations;

namespace backend.Dtos.Recipes.PreparationStep;

public class PreparationStepWithoutId
{
    [Required]
    [StringLength(750, MinimumLength = 2)]
    public required string Description { get; set; }
    [Required]
    public required int Step { get; set; }
}
