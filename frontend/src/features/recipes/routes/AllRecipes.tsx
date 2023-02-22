import { useState, useEffect } from "react";
import { TRecipe } from "../types";
import { RecipesApi } from "../api/RecipesApi";
import { RecipeImage } from "../components/RecipeImage";
import { RecipeHeader } from "../components/RecipeHeader";
import { RecipeDescription } from "../components/RecipeDescription";
import { RecipeIngredients } from "../components/RecipeIngredients";
import { RecipePreparation } from "../components/RecipePreparation";
import { RecipeButtons } from "../components/RecipeButtons";

export const AllRecipes = () => {
    const [recipes, setRecipes] = useState<TRecipe[]>([]);
    useEffect(() => {
        const fetchData = async () => {
            const result = await RecipesApi.getAll();
            setRecipes(result);
        };
        fetchData();
    }, []);

    console.log(recipes)
    if (!recipes) return (<div>Loading...</div>);
    return (
        
            <div>
                {recipes.map(recipe => (
                    <div key={recipe.id}>
                        <div >
                            <h1>HII!!</h1>
                            <RecipeImage id={recipe.id} name={recipe.name} />
                            <div className="card-body recipe-info">
                                <RecipeHeader recipe={recipe} />
                                <RecipeDescription description={recipe.description} />
                                <h3 >Ingredients</h3>
                                <RecipeIngredients ingredients={recipe.recipeIngredients} />
                            </div>
                        </div>
                        <RecipePreparation preparationSteps={recipe.preparationSteps} />
                        <RecipeButtons recipeId={recipe.id} />
                    </div>
                ))}
            </div>
    );
};