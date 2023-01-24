using ElProyecteGrande.Models;
using System.ComponentModel.DataAnnotations;

namespace ElProyecteGrande.Models_Miki
{
    public class Category : BaseModel
    {
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public required string Name { get; set; }
    }
}
