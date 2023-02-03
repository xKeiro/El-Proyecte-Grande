using ElProyecteGrande.Models.Categories;
using Microsoft.EntityFrameworkCore;
using ElProyecteGrande.Interfaces.Services;
using ElProyecteGrande.Dtos.Categories.Diet;
using AutoMapper;

namespace ElProyecteGrande.Services.Categories
{
    public class DietService : IBasicCrudService<DietPublic, DietWithoutId>
    {
        private readonly ElProyecteGrandeContext _context;
        private readonly IMapper _mapper;
        public DietService(ElProyecteGrandeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DietPublic> Add(DietWithoutId dietWithoutId)
        {
            var diet = _mapper.Map<DietWithoutId, Diet>(dietWithoutId);
            await _context.Diets.AddAsync(diet);
            await _context.SaveChangesAsync();
            return _mapper.Map<Diet, DietPublic>(diet);
        }

        public async Task<List<DietPublic>> GetAll()
        {
            var diets = await _context
                .Diets
                .AsNoTracking()
                .ToListAsync();
            return _mapper.Map<List<Diet>, List<DietPublic>>(diets);
        }

        public async Task<DietPublic?> Find(int id)
        {
            var diet = await _context.Diets
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
            if (diet is null)
            {
                return null;
            }
            return _mapper.Map<Diet, DietPublic>(diet);
        }

        public async Task<DietPublic> Update(int id, DietWithoutId dietWithoutId)
        {
            var diet = _mapper.Map<DietWithoutId, Diet>(dietWithoutId);
            diet.Id = id;
            _context.Update(diet);
            await _context.SaveChangesAsync();
            return _mapper.Map<Diet, DietPublic>(diet);
        }

        public async Task<bool> IsUnique(DietWithoutId dietWithoutId)
        {
            var diet = _mapper.Map<DietWithoutId, Diet>(dietWithoutId);
            return !await _context.Diets.AnyAsync(c => c.Name.ToLower() == diet.Name.ToLower());
        }

    }
}
