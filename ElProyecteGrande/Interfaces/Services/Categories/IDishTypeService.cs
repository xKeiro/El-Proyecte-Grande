using ElProyecteGrande.Models.Categories;

namespace ElProyecteGrande.Interfaces.Services.Categories
{
    public interface IDishTypeService
    {
        Task<IEnumerable<DishType>> GetAllDishType();
        Task AddDishType(DishType dishType);
        Task<DishType> GetDishTypeByName(string name);
        void UpdateDishType(DishType newDishType);
    }
}
