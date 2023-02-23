import { useState, useEffect } from "react";
import { TRecipe } from "../types";
import { RecipesApi } from "../api/RecipesApi";
import { RecipeImage } from "../components/RecipeImage";
import { Link } from "react-router-dom";

export const AllRecipes = () => {
    const [recipes, setRecipes] = useState<TRecipe[]>([]);
    useEffect(() => {
        const fetchData = async () => {
            const result = await RecipesApi.getAll();
            setRecipes(result);
        };
        fetchData();
    }, []);

    if (!recipes) return (<div>Loading...</div>);
    return (
        <div className="grid grid-cols-2 gap-4">
            {recipes.map(recipe => (
                <div key={recipe.id} className="card w-96 bg-base-200 shadow-xl">
                    <figure className="px-10 pt-10 rounded-x">
                        <RecipeImage id={recipe.id} name={recipe.name} size={{ width: 200, height: 250 }} />
                    </figure>
                    <div className="card-body items-center text-center">
                        <h2 className="card-title">{recipe.name}</h2>
                        <p>{recipe.description}</p>
                        <div className="card-actions">
                            <Link to={`/recipes/` + recipe.id}><u>More info...</u></Link>
                        </div>
                    </div>
                </div>

            ))}

        </div>
    );
};