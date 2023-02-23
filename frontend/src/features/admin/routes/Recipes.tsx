import { useEffect, useState } from 'react';
import { Link, Navigate } from 'react-router-dom';
import { RecipesApi } from '@/features/recipes/api/RecipesApi';
import { TRecipe } from '@/features/recipes';
import { RecipeSearchBox } from "@/features/recipes/components/RecipeSearchBox";

export const Recipes = () => {
  const [recipes, setRecipes] = useState<TRecipe[]>([]);
  const [searchTerm, setSearchTerm] = useState<string>('');

  let isAdmin = true;

  useEffect(() => {
    const fetchData = async () => {
      const result = await RecipesApi.getAll();
      setRecipes(result);
    };
    fetchData();
  }, []);

  const handleSearch = async (name : string = "") => {
      const recipesList = await RecipesApi.filterRecipes([], [], [], [], [], name);
      setRecipes(recipesList);
  }

  if (isAdmin)
  return (
    <div id="recipes-container" className="text-base-content">
      <RecipeSearchBox searchTerm={searchTerm} setSearchTerm={setSearchTerm} handleRecipeSearch={handleSearch} />
      <div className="grid grid-cols-4 gap-5 text-center py-5">
        {recipes.map((recipe) => (
          <Link key={recipe.id} to={`/admin/recipes/${recipe.id}`} className="hover:underline">
            {recipe.name}
          </Link>
      ))}
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
