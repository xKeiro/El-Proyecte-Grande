﻿using ElProyecteGrande.Models.Categories;

namespace ElProyecteGrande.Services.Category
{
    public interface IMealTimeService
    {
        Task<IEnumerable<MealTime>> GetAllMealTime();
        Task AddMealTime(MealTime mealTime);
        Task<MealTime> GetMealTimeByName(string name);
        void UpdateMealTime(MealTime newMealTime);
    }
}
