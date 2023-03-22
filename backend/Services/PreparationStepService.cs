using AutoMapper;
using backend.Dtos.Ingredient;
using backend.Dtos.Recipes.PreparationStep;
using backend.Interfaces.Services;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class PreparationStepService : IBasicCrudService<PreparationStepPublic, PreparationStepWithoutId>
    {
        private readonly ElProyecteGrandeContext _context;
        private readonly IMapper _mapper;
        public PreparationStepService(ElProyecteGrandeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<PreparationStepPublic>> GetAll()
        {
            var preparationSteps = await _context
                .PreparationSteps
                .AsNoTracking()
                .ToListAsync();
            return _mapper.Map<List<PreparationStep>, List<PreparationStepPublic>>(preparationSteps);

        }

        public async Task<PreparationStepPublic> Add(PreparationStepWithoutId preparationStepWithoutId)
        {
            var preparationStep = _mapper.Map<PreparationStepWithoutId, PreparationStep>(preparationStepWithoutId);
            _ = await _context.PreparationSteps.AddAsync(preparationStep);
            _ = await _context.SaveChangesAsync();
            return _mapper.Map<PreparationStep, PreparationStepPublic>(preparationStep);
        }

        public async Task<PreparationStepPublic?> Find(int id)
        {
            var preparationStep = await _context.PreparationSteps
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
            return preparationStep switch
            {
                null => null,
                _ => _mapper.Map<PreparationStep, PreparationStepPublic>(preparationStep)
            };
        }

        public async Task<PreparationStepPublic> Update(int id, PreparationStepWithoutId preparationStepWithoutId)
        {
            var preparationStep = _mapper.Map<PreparationStepWithoutId, PreparationStep>(preparationStepWithoutId);
            preparationStep.Id = id;
            _ = _context.Update(preparationStep);
            _ = await _context.SaveChangesAsync();
            return _mapper.Map<PreparationStep, PreparationStepPublic>(preparationStep);
        }

        public async Task<bool> IsUnique(PreparationStepWithoutId preparationStepWithoutId)
        {
            var preparationStep = _mapper.Map<PreparationStepWithoutId, PreparationStep>(preparationStepWithoutId);
            return !await _context.PreparationSteps.AnyAsync(p => p.Description.ToLower() == preparationStep.Description.ToLower());
        }
    }
}
