using ElProyecteGrande.Models.Categories;

namespace ElProyecteGrande.Interfaces.Services
{
    public interface IBasicCrudService<T> where T : class
    {
        Task<List<T>> GetAll();
        Task Add(T model);
        Task<T?> Find(int id);
        Task Update(T model);
        Task Delete(T model);
        Task<bool> IsUnique(T model);
    }
}
