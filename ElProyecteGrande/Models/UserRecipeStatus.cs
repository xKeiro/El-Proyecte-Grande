using System.ComponentModel.DataAnnotations;

namespace ElProyecteGrande.Models
{
    public class UserRecipeStatus : BaseModel
    {
        [Required]
        public User User { get; set; }

        [Required]
        public Recipe Recipe { get; set; }

        [Required] 
        public bool Liked { get; set; } = false;

        [Required]
        public bool Disliked { get; set; } = false;

        [Required]
        public bool Saved { get; set; } = false;
    }
}
