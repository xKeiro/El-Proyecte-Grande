import { useEffect, useState } from 'react';
import { Navigate, useParams} from 'react-router-dom';
import { RecipesApi } from '@/features/recipes/api/RecipesApi';
import { TRecipe } from '@/features/recipes';
import { RecipeHeader } from '@/features/recipes/components/RecipeHeader';
import { RecipeImage } from '@/features/recipes/components/RecipeImage';
import { RecipeDescription } from '@/features/recipes/components/RecipeDescription';
import { RecipeIngredients } from '@/features/recipes/components/RecipeIngredients';
import { RecipePreparation } from '@/features/recipes/components/RecipePreparation';
import { RecipeButtons } from '@/features/admin/components/RecipeButtons';

export const AdminRecipe = ({ isAdmin } : { isAdmin : boolean }) => {
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
        <div className="grid grid-cols-1 md:grid-cols-2 gap-4 place-items-center shadow-xl">
            <div className="bg-base-100 md:pl-6 xl:w-96 2xl:w-96">
                <RecipeImage id={recipe.id} name={recipe.name} />
            </div>
            <div className="recipe-info md:place-items-start p-4 ">
                <RecipeHeader recipe={recipe} />
                <RecipeDescription description={recipe.description} />
            <h3 className="recipe-sub-title font-bold text-xl">Ingredients</h3>
                <RecipeIngredients ingredients={recipe.recipeIngredients} />
            </div>
            <div className="md:col-span-2">
                <RecipePreparation preparationSteps={recipe.preparationSteps} />
            </div>
            <div className="md:col-span-2 pb-6 justify-self-end px-6">
                <RecipeButtons recipeId={recipe.id} />
            </div>
        </div>
    );
};
