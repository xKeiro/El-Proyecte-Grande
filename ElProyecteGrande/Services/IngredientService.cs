﻿using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using ElProyecteGrande.Interfaces.Services;
using ElProyecteGrande.Models;

namespace ElProyecteGrande.Services
{
    public class IngredientService: IBasicCrudService<Ingredient>
    {
        private readonly ElProyecteGrandeContext _context;
        public IngredientService(ElProyecteGrandeContext context)
        {
            _context = context;
        }

        public async Task Add(Ingredient ingredient)
        {
            await _context.Ingredients.AddAsync(ingredient);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Ingredient ingredient)
        {
            _context.Ingredients.Remove(ingredient);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Ingredient>> GetAll()
        {
            return await _context
                .Ingredients
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Ingredient?> Find(int id)
        {
            return await _context.Ingredients.FindAsync(id);
        }
        
        public async Task Update(Ingredient ingredient)
        {
            EntityEntry entityEntry = _context.Entry(ingredient);
            entityEntry.State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsUnique(Ingredient ingredient)
        {
            bool isUnique = !await _context.Ingredients.AnyAsync(c => c.Name == ingredient.Name);
            return isUnique;
        }
    }
}