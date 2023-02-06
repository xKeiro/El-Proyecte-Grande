using Microsoft.EntityFrameworkCore;

namespace ElProyecteGrande.Models.Categories;

/// <summary>
/// Type of a dish, like - soup, pizza, pasta, etc.
/// </summary>
[Index(nameof(Name), IsUnique = true)]
public class DishType : BaseCategory
{
}