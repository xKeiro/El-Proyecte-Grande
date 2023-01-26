using ElProyecteGrande.Models.Dto.Users;
using ElProyecteGrande.Models.Users;

namespace ElProyecteGrande.Interfaces.Services
{
    public interface IUserService
    {
        Task<List<UserPublic>> GetAll();
    }
}
