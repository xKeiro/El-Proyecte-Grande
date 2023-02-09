import { RecipesApi } from '@/features/recipes/api/RecipesApi';
import { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import { TRecipe } from '@/features/recipes';

const Recipes = () => {
  const [recipes, setRecipes] = useState<TRecipe[]>([]);
  useEffect(() => {
    const fetchData = async () => {
      const result = await RecipesApi.getAll();
      setRecipes(result);
    };
    fetchData();
  }, []);

  return (
    <div id="recipes-container" className="grid grid-cols-4 gap-5 text-center py-5">
      {recipes.map((recipe) => (
        <Link key={recipe.id} to={`/recipes/${recipe.id}`} state={recipe} className="text-neutral-content hover:underline">
          {recipe.name}
        </Link>
      ))}
    </div>
  );
};

export default Recipes;
