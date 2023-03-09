using AutoMapper;
using backend.Dtos.Recipes.Recipe;
using backend.Dtos.Users.User;
using backend.Enums;
using backend.Interfaces.Services;
using backend.Models.Recipes;
using backend.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace backend.Services.Users;

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
        return !await _context.Users.AnyAsync(u =>
            u.Username == user.Username || u.EmailAddress == user.EmailAddress);
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

    // Need to change to return DTO
    public async Task<User?> FindByUsername(string username)
    {
        var resUser = await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Username == username);
        return resUser;
    }

    public async Task<bool> IsUniqueUsername(UserWithoutId userWithoutId)
    {
        var user = _mapper.Map<UserWithoutId, User>(userWithoutId);
        return !await _context.Users.AnyAsync(u => u.Username == user.Username);
    }

    public async Task<bool> IsUniqueEmail(UserWithoutId userWithoutId)
    {
        var user = _mapper.Map<UserWithoutId, User>(userWithoutId);
        return !await _context.Users.AnyAsync(u => u.EmailAddress == user.EmailAddress);
    }

    public async Task<List<RecipePublic>> LikedRecipes(int userId)
    {
        var result = await (from u in _context.Users
                            join rs in _context.UserRecipes on u.Id equals rs.User.Id
                            join r in _context.Recipes on rs.Recipe.Id equals r.Id
                            where u.Id == userId && rs.Status.Name == RecipeStatus.Liked
                            select _mapper.Map<Recipe, RecipePublic>(r)).ToListAsync();
        return result;
    }

    public async Task<List<RecipePublic>> SavedRecipes(int userId)
    {
        var result = await (from u in _context.Users
                            join rs in _context.UserRecipes on u.Id equals rs.User.Id
                            join r in _context.Recipes on rs.Recipe.Id equals r.Id
                            where u.Id == userId && rs.Status.Name == RecipeStatus.Saved
                            select _mapper.Map<Recipe, RecipePublic>(r)).ToListAsync();
        return result;
    }

    public async Task<List<RecipePublic>> DislikedRecipes(int userId)
    {
        var result = await (from u in _context.Users
                            join rs in _context.UserRecipes on u.Id equals rs.User.Id
                            join r in _context.Recipes on rs.Recipe.Id equals r.Id
                            where u.Id == userId && rs.Status.Name == RecipeStatus.Disliked
                            select _mapper.Map<Recipe, RecipePublic>(r)).ToListAsync();
        return result;
    }
}