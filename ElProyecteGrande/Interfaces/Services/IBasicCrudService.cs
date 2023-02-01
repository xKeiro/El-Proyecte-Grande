namespace ElProyecteGrande.Interfaces.Services
{
    public interface IBasicCrudService<ResponseDto, RequestDto> where ResponseDto : class where RequestDto : class
    {
        Task<List<ResponseDto>> GetAll();
        Task<ResponseDto> Add(RequestDto requestDto);
        Task<ResponseDto?> Find(int id);
        Task<ResponseDto> Update(int id, RequestDto requestDto);
        Task<bool> IsUnique(RequestDto requestDto);
    }
}
