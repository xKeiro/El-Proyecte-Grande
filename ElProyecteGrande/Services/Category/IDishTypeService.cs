﻿using ElProyecteGrande.Models.Categories;

namespace ElProyecteGrande.Services.Category
{
    public interface IDishTypeService
    {
        Task<IEnumerable<DishType>> GetAllDishType();
    }
}
