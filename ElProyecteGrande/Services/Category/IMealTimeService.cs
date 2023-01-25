using ElProyecteGrande.Models.Categories;

namespace ElProyecteGrande.Services.Category
{
    public interface IMealTimeService
    {
        Task<IEnumerable<MealTime>> GetAllMealTime();
        Task AddMealTime(MealTime mealTime);
    }
}
