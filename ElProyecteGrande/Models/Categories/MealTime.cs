using ElProyecteGrande.Models.Recipes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ElProyecteGrande.Models.Categories;

/// <summary>
/// Time of a meal, like - breakfast, lunch, dinner
/// </summary>
[Index(nameof(Name), IsUnique = true)]
public class MealTime : BaseCategory
{
}
