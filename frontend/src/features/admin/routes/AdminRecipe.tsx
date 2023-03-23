import { useEffect, useState } from 'react';
import { Navigate, useParams } from 'react-router-dom';
import { RecipesApi } from '@/features/recipes/api/RecipesApi';
import { TRecipe } from '@/features/recipes';
import { RecipeHeader } from '@/features/recipes/components/RecipeHeader';
import { RecipeImage } from '@/features/recipes/components/RecipeImage';
import { RecipeDescription } from '@/features/recipes/components/RecipeDescription';
import { RecipeIngredients } from '@/features/recipes/components/RecipeIngredients';
import { RecipePreparation } from '@/features/recipes/components/RecipePreparation';
import { RecipeButtons } from '@/features/admin/components/RecipeButtons';

export const AdminRecipe = ({ isAdmin, username } : { isAdmin : boolean, username : string | null }) => {
    const [recipe, setRecipe] = useState<TRecipe | null>(null);
    const { id } = useParams<{ id: string }>();
    const idNumeric = parseInt(id!);

    useEffect(() => {
        RecipesApi.get(idNumeric).then((recipe: TRecipe) => {
            setRecipe(recipe);
        });
    }, []);
    if (!isAdmin) return (<Navigate to="/unauthorized" />);
    if (!recipe) return (<div>Loading...</div>);
    return (
        <div className="card shadow-xl">
            <div className="card card-side bg-base-100">
                <RecipeImage id={recipe.id} name={recipe.name} />
                <div className="card-body recipe-info">
                    <RecipeHeader recipe={recipe} username={username} />
                    <RecipeDescription description={recipe.description} />
                    <h3 className="recipe-sub-title font-bold text-xl">Ingredients</h3>
                    <RecipeIngredients ingredients={recipe.recipeIngredients} />
                </div>
            </div>
            <RecipePreparation preparationSteps={recipe.preparationSteps} />
            <RecipeButtons recipeId={recipe.id} />
        </div>
    );
};
