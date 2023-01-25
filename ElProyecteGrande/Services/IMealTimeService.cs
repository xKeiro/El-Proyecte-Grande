using ElProyecteGrande.Models.Categories;

namespace ElProyecteGrande.Services
{
    public interface IMealTimeService
    {
        Task<IEnumerable<MealTime>> GetAllMealTime();
    }
}
