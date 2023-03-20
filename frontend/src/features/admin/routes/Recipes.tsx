import { useEffect, useState } from 'react';
import { Link, Navigate } from 'react-router-dom';
import { RecipesApi } from '@/features/recipes/api/RecipesApi';
import { TRecipe, TRecipesFilter, TRecipesWithPagination } from '@/features/recipes';
import { RecipeSearchBox } from "@/features/recipes/components/RecipeSearchBox";
import { RecipeAddNew } from '../components/RecipeAddNew';

export const Recipes = ({ isAdmin }: { isAdmin: boolean }) => {
  const [recipesWithPagination, setRecipesWithPagination] = useState<TRecipesWithPagination | null>(null);
  const [searchTerm, setSearchTerm] = useState<string>('');

  useEffect(() => {
    const fetchData = async () => {
      handleSearch();
    };
    fetchData();
  }, []);

  const handleSearch = async (searchString: string = "") => {
    const filter: TRecipesFilter = {
      cuisineIds: [],
      dietIds: [],
      ingredientIds: [],
      mealTimeIds: [],
      dishTypeIds: [],
      searchString: searchString,
      preparationMaxDifficulty: null,
      maxNotOwnedIngredients: 0,
      page: 1,
      recipesPerPage: 50
    }
    const recipesList = await RecipesApi.filterRecipes(filter);
    setRecipesWithPagination(recipesList);
  }

  if (isAdmin)
    return (
      <div id="recipes-container" className="text-base-content">
        <div className='text-center'>
          <RecipeSearchBox searchTerm={searchTerm} setSearchTerm={setSearchTerm} handleRecipeSearch={handleSearch} />
        </div>
        <div className="grid grid-cols-4 gap-5 text-center py-5">
          {recipesWithPagination?.recipes.map((recipe) => (
            <Link key={recipe.id} to={`/admin/recipes/${recipe.id}`} className="hover:underline">
              {recipe.name}
            </Link>
          ))}
            </div>

            <div className='flex justify-center mt-4'>
                <Link to="/admin/recipes/add" className="btn btn-primary">Add New Recipe</Link>
            </div>

        <div className="btn-group w-full justify-center mt-8">
          <button className="btn btn-md">1</button>
          <button className="btn btn-md">2</button>
          <button className="btn btn-md">3</button>
          <button className="btn btn-md">4</button>
        </div>
      </div>
    );
  return (<Navigate to="/unauthorized" />)
};
