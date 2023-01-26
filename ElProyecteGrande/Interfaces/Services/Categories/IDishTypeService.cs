using ElProyecteGrande.Models.Categories;

namespace ElProyecteGrande.Interfaces.Services.Categories
{
    public interface IDishTypeService
    {
        Task<IEnumerable<DishType>> GetAllDishType();
    }
}
