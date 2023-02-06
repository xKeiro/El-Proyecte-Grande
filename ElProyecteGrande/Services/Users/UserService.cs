using AutoMapper;
using ElProyecteGrande.Dtos.Users.User;
using ElProyecteGrande.Interfaces.Services;
using ElProyecteGrande.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace ElProyecteGrande.Services.Users;

public class UserService : IUserService<UserPublic, UserWithoutId>
{
    private readonly ElProyecteGrandeContext _context;
    private readonly IMapper _mapper;
    public UserService(ElProyecteGrandeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<UserPublic> Add(UserWithoutId userWithoutId)
    {
        var user = _mapper.Map<UserWithoutId, User>(userWithoutId);
        _ = await _context.Users.AddAsync(user);
        _ = await _context.SaveChangesAsync();
        return _mapper.Map<User, UserPublic>(user);
    }

    public async Task<List<UserPublic>> GetAll()
    {
        var users = await _context
            .Users
            .AsNoTracking()
            .ToListAsync();
        return _mapper.Map<List<User>, List<UserPublic>>(users);
    }

    public async Task<UserPublic?> Find(int id)
    {
        var user = await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);
        return user switch
        {
            null => null,
            _ => _mapper.Map<User, UserPublic>(user)
        };
    }

    public async Task<UserPublic> Update(int id, UserWithoutId userWithoutId)
    {
        var user = _mapper.Map<UserWithoutId, User>(userWithoutId);
        user.Id = id;
        _ = _context.Update(user);
        _ = await _context.SaveChangesAsync();
        return _mapper.Map<User, UserPublic>(user);
    }

    public async Task<bool> IsUnique(UserWithoutId userWithoutId)
    {
        var user = _mapper.Map<UserWithoutId, User>(userWithoutId);
        return !await _context.Users.AnyAsync(u => u.Username == user.Username || u.EmailAddress.ToLower() == user.EmailAddress.ToLower());
    }

    public async Task<bool> Delete(int id)
    {
        var user = await _context.Users
             .FirstOrDefaultAsync(user => user.Id == id);
        var userRecipe = await _context.UserRecipes
            .FirstOrDefaultAsync(userRecipe => userRecipe.User == user);
        switch (user)
        {
            case null:
                return false;
        }

        switch (userRecipe)
        {
            case not null:
                _ = _context.UserRecipes.Remove(userRecipe);
                break;
        }

        _ = _context.Users.Remove(user);
        _ = await _context.SaveChangesAsync();
        return true;
    }
}