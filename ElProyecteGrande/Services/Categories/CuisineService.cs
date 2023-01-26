﻿using ElProyecteGrande.Models.Categories;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using ElProyecteGrande.Interfaces.Services;

namespace ElProyecteGrande.Services.Categories
{
    public class CuisineService : IBasicCrudService<Cuisine>
    {
        private readonly ElProyecteGrandeContext _context;
        public CuisineService(ElProyecteGrandeContext context)
        {
            _context = context;
        }

        public async Task Add(Cuisine cuisine)
        {
            await _context.Cuisine.AddAsync(cuisine);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Cuisine cuisine)
        {
            _context.Cuisine.Remove(cuisine);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Cuisine>> GetAll()
        {
            return await _context
                .Cuisine
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Cuisine?> Find(int id)
        {
            return await _context.Cuisine.FindAsync(id);
        }

        public async Task Update(Cuisine cuisine)
        {
            _context.Update(cuisine);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsUnique(Cuisine cuisine)
        {
            return !await _context.Cuisine.AnyAsync(c => c.Name == cuisine.Name);
        }
    }
}
