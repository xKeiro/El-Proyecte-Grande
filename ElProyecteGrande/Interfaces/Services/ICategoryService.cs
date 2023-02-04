using ElProyecteGrande.Dtos.Recipes.Recipe;

namespace ElProyecteGrande.Interfaces.Services
{
    public interface ICategoryService<ResponseDto, RequestDto> : IBasicCrudService<ResponseDto, RequestDto> where ResponseDto : class where RequestDto : class
    {
        Task<List<RecipePublic>?> GetRecipes(int categoryId);
    }
}
