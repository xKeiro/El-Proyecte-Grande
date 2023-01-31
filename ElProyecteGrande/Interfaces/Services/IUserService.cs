using ElProyecteGrande.Dtos.Users.User;
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
        Task Update(User user);
        Task<bool> IsUnique(User user);
    }
}
