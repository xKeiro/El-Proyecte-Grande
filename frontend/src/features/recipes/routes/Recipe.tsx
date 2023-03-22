import { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { RecipesApi } from '../api/RecipesApi';
import { TRecipe } from '@/features/recipes';
import { RecipeHeader } from '../components/RecipeHeader';
import { RecipeImage } from '../components/RecipeImage';
import { RecipeDescription } from '../components/RecipeDescription';
import { RecipeIngredients } from '../components/RecipeIngredients';
import { RecipePreparation } from '@/features/recipes/components/RecipePreparation';

export const Recipe = ({ username } : { username : string | null }) => {
  const [recipe, setRecipe] = useState<TRecipe | null>(null);
  const { id } = useParams<{ id: string }>();
  const idNumeric = parseInt(id!);

  useEffect(() => {
    RecipesApi.get(idNumeric).then((recipe: TRecipe) => {
      setRecipe(recipe);
    });
  }, []);

  if (!recipe) return (<div>Loading...</div>);
  return (
    <div className="grid grid-cols-1 md:grid-cols-1 gap-4 place-items-center shadow-xl">
      <div className="bg-base-100">
        <RecipeImage id={recipe.id} name={recipe.name} />
      </div>
      <div className="recipe-info md:max-lg:w-96 p-4">
        <RecipeHeader recipe={recipe} username={username} />
        <RecipeDescription description={recipe.description} />
        <h3 className="recipe-sub-title font-bold text-xl">Ingredients</h3>
        <RecipeIngredients ingredients={recipe.recipeIngredients} />
      </div>
      <div className="md:col-span-2">
        <RecipePreparation preparationSteps={recipe.preparationSteps} />
      </div>
    </div>
  );
};
