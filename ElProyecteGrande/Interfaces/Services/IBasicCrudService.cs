namespace ElProyecteGrande.Interfaces.Services
{
    public interface IBasicCrudService<TResponseDto, TRequestDto> where TResponseDto : class where TRequestDto : class
    {
        Task<List<TResponseDto>> GetAll();
        Task<TResponseDto> Add(TRequestDto requestDto);
        Task<TResponseDto?> Find(int id);
        Task<TResponseDto> Update(int id, TRequestDto requestDto);
        Task<bool> IsUnique(TRequestDto requestDto);
    }
}
