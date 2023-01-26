using ElProyecteGrande.Models.Categories;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ElProyecteGrande.Models.DTOs.Categories;

/// <summary>
/// Time of a meal, like - breakfast, lunch, dinner
/// </summary>

[Index(nameof(Name), IsUnique = true)]
public class MealTimeWithoutCategorizations : BaseCategory
{
    public MealTimeWithoutCategorizations()
    {

    }

    public MealTimeWithoutCategorizations(MealTime mealTime)
    {
        Name = mealTime.Name;
        Id = mealTime.Id;
    }

    public void MapTo(MealTime mealTime)
    {
        mealTime.Name = Name;
        mealTime.Id = Id;
    }

    public void MapFrom(MealTime mealTime)
    {
        Name = mealTime.Name;
        Id = mealTime.Id;
    }
}