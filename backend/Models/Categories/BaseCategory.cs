using ElProyecteGrande.Models.Recipes;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ElProyecteGrande.Models.Categories;

public abstract class BaseCategory : BaseModel
{
    [Required]
    [StringLength(20, MinimumLength = 2)]
    public required string Name { get; set; }

    [Required]
    [JsonIgnore]
    public ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
}