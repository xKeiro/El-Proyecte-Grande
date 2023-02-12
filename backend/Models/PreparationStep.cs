using System.ComponentModel.DataAnnotations;

namespace backend.Models;

public class PreparationStep : BaseModel
{
    [Required]
    [StringLength(750, MinimumLength = 2)]
    public required string Description { get; set; }
    [Required]
    public required int Step { get; set; }
}
