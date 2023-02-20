import { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { RecipesApi } from '../api/RecipesApi';
import { TRecipe } from '@/features/recipes';
import { RecipeHeader } from '../../admin/components/RecipeHeader';
import { RecipeImage } from '../../admin/components/RecipeImage';
import { RecipeDescription } from '../../admin/components/RecipeDescription';
import { RecipeIngredients } from '../../admin/components/RecipeIngredients';
import { RecipePreparation } from '@/features/admin/components/RecipePreparation';
import { RecipeButtons } from '@/features/admin/components/RecipeButtons';

export const Recipe = () => {
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
    <div className="card shadow-xl">
      <div className="card card-side bg-base-100">
        <RecipeImage />
        <div className="card-body recipe-info">
          <RecipeHeader recipe={recipe} />
          <RecipeDescription description={recipe.description} />
          <h3 className="recipe-sub-title font-bold text-xl">Ingredients</h3>
          <RecipeIngredients ingredients={recipe.recipeIngredients} />
        </div>
      </div>
      <RecipePreparation />
      <RecipeButtons recipeId={recipe.id} />
    </div>
  );
};
