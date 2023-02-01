namespace ElProyecteGrande.Interfaces.Services
{
    public interface IRecipeService<ResponseDto, RequestDto> :
        IBasicCrudService<ResponseDto, RequestDto> 
        where ResponseDto : class
        where RequestDto : class
    {
        Task<bool> Delete(int id);
    }
}
