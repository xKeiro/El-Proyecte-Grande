using Microsoft.EntityFrameworkCore;

namespace backend.Models.Categories;

/// <summary>
/// Time of a meal, like - breakfast, lunch, dinner.
/// </summary>
[Index(nameof(Name), IsUnique = true)]
public class MealTime : BaseCategory
{
}