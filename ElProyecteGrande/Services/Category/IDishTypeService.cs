using ElProyecteGrande.Models.Categories;

namespace ElProyecteGrande.Services.Category
{
    public interface IDishTypeService
    {
        Task<IEnumerable<DishType>> GetAllDishType();
        Task AddDishType(DishType dishType);
        Task<DishType> GetDishTypeByName(string name);
        void UpdateDishType(DishType newDishType);
    }
}
