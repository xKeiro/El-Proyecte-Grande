using Microsoft.EntityFrameworkCore;

namespace backend.Models.Categories;

/// <summary>
/// Different type of cuisines, like - Hungarian, Italian, French, etc.
/// </summary>
[Index(nameof(Name), IsUnique = true)]
public class Cuisine : BaseCategory
{
}