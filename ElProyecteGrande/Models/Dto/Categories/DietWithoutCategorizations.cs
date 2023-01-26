using ElProyecteGrande.Models.Categories;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ElProyecteGrande.Models.DTOs.Categories;

/// <summary>
/// Different type of diets, like - vegetarian, gluten free, paleo etc.
/// </summary>

[Index(nameof(Name), IsUnique = true)]
public class DietWithoutCategorizations: BaseCategory
{
    public DietWithoutCategorizations()
    {
        
    }

    public DietWithoutCategorizations( Diet diet)
    {
        Name = diet.Name;
        Id = diet.Id;
    }

    public void MapTo(Diet diet)
    {
        diet.Name = Name;
        diet.Id = Id;
    }

    public void MapFrom(Diet diet)
    {
        Name = diet.Name;
        Id = diet.Id;
    }
}