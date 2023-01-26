using ElProyecteGrande.Models.Categories;

namespace ElProyecteGrande.Interfaces.Services.Categories
{
    public interface IMealTimeService
    {
        Task<IEnumerable<MealTime>> GetAllMealTime();
    }
}
