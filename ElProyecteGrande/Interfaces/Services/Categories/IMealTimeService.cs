using ElProyecteGrande.Models.Categories;

namespace ElProyecteGrande.Interfaces.Services.Categories
{
    public interface IMealTimeService
    {
        Task<IEnumerable<MealTime>> GetAllMealTime();
        Task AddMealTime(MealTime mealTime);
        Task<MealTime> GetMealTimeByName(string name);
        void UpdateMealTime(MealTime newMealTime);
    }
}
