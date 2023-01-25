using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ElProyecteGrande.Models.Categories;

[Index(nameof(Name), IsUnique = true)]
public class Diet : BaseCategory
{
    [Required]
    public ICollection<Categorization> Categorizations { get; set; }
}
