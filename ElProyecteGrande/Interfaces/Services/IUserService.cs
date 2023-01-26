using ElProyecteGrande.Models.Dto.Users;
using ElProyecteGrande.Models.Users;

namespace ElProyecteGrande.Interfaces.Services
{
    public interface IUserService
    {
        Task<List<UserPublic>> GetAll();
        Task Add(User user);
        Task<User?> Find(int id);
        Task<UserPublic?> FindPublic(int id);
        Task Delete(User user);
        Task<bool> IsUnique(User user);
    }
}
