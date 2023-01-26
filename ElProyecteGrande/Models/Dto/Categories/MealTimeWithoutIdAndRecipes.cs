using ElProyecteGrande.Models.Categories;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ElProyecteGrande.Models.Dto.Categories
{
    /// <summary>
    /// Time of a meal, like - breakfast, lunch, dinner
    /// </summary>
    [Index(nameof(Name), IsUnique = true)]
    public class MealTimeWithoutIdAndRecipes
    {
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public required string Name { get; set; }

        public void MapTo(MealTime mealTime)
        {
            mealTime.Name = Name;
        }
    }
}