using ElProyecteGrande.Models.Categories;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using ElProyecteGrande.Interfaces.Services;
using ElProyecteGrande.Dtos.Categories.Cuisine;
using AutoMapper;

namespace ElProyecteGrande.Services.Categories
{
    public class CuisineService : IBasicCrudService<CuisinePublic, CuisineWithoutId>
    {
        private readonly ElProyecteGrandeContext _context;
        private readonly IMapper _mapper;
        public CuisineService(ElProyecteGrandeContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CuisinePublic> Add(CuisineWithoutId cuisineWithoutId)
        {
            var cuisine = _mapper.Map<CuisineWithoutId, Cuisine>(cuisineWithoutId);
            await _context.Cuisines.AddAsync(cuisine);
            await _context.SaveChangesAsync();
            return _mapper.Map<Cuisine, CuisinePublic>(cuisine);
        }

        public async Task<List<CuisinePublic>> GetAll()
        {
            var cuisines = await _context
                .Cuisines
                .AsNoTracking()
                .ToListAsync();
            return _mapper.Map<List<Cuisine>, List<CuisinePublic>>(cuisines);
        }

        public async Task<CuisinePublic?> Find(int id)
        {
            var cuisine = await _context.Cuisines
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
            if (cuisine is null)
            {
                return null;
            }
            return _mapper.Map<Cuisine, CuisinePublic>(cuisine);
        }

        public async Task<CuisinePublic> Update(int id, CuisineWithoutId cuisineWithoutId)
        {
            var cuisine = _mapper.Map<CuisineWithoutId, Cuisine>(cuisineWithoutId);
            cuisine.Id = id;
            _context.Update(cuisine);
            await _context.SaveChangesAsync();
            return _mapper.Map<Cuisine, CuisinePublic>(cuisine);
        }

        public async Task<bool> IsUnique(CuisineWithoutId cuisineWithoutId)
        {
            var cuisine = _mapper.Map<CuisineWithoutId, Cuisine>(cuisineWithoutId);
            return !await _context.Cuisines.AnyAsync(c => c.Name.ToLower() == cuisine.Name.ToLower());
        }

    }
}
