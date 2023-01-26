using ElProyecteGrande.Models.Categories;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ElProyecteGrande.Models.Dto.Categories
{
    /// <summary>
    /// Type of a dish, like - soup, pizza, pasta, etc.
    /// </summary>
    [Index(nameof(Name), IsUnique = true)]
    public class DishTypeWithoutId
    {
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public required string Name { get; set; }

        public void MapTo(DishType dishType)
        {
            dishType.Name = Name;
        }
    }
}