using Microsoft.EntityFrameworkCore;

namespace ElProyecteGrande.Models.Categories;

/// <summary>
/// Different type of diets, like - vegetarian, gluten free, paleo etc.
/// </summary>
///
[Index(nameof(Name), IsUnique = true)]
public class Diet : BaseCategory
{
}