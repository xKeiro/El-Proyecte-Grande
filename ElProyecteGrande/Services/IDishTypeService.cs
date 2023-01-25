using ElProyecteGrande.Models.Categories;

namespace ElProyecteGrande.Services
{
    public interface IDishTypeService
    {
        Task<IEnumerable<DishType>> GetAllDishType();
    }
}
