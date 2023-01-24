using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ElProyecteGrande.Models
{
    public class RecipeReview : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public Recipe Recipe { get; set; }

        [Required]
        [Range(1, 5)]
        public int Rate { get; set; }

        public string? Review { get; set; }

    }
}
