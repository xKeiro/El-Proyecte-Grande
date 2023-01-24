using System.ComponentModel.DataAnnotations;

namespace ElProyecteGrande.Models.Users
{
    public class UserRecipeStatus : BaseModel
    {
        [Required]
        [RegularExpression("Liked|Disliked|Saved", ErrorMessage = "The status should be either Liked, Disliked or Saved!")]
        public required string Name { get; set; }
    }
}
