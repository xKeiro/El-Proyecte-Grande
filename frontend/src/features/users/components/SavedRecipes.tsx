import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { fetchSavedRecipes } from '../api/getSavedRecipesByUser';

const SavedRecipes = () => {
    const [savedRecipes, setSavedRecipes] = useState<any>({});
    const { id } = useParams();


    useEffect(() => {
        const fetchData = async () => {
            const data = await fetchSavedRecipes(id);
            setSavedRecipes(data);
            console.log(data);
        };
        fetchData();
    }, [id]);

    return (

        <div tabIndex={0} className="collapse collapse-arrow w-6/12">
            <input type="checkbox" />
            <div className="collapse-title text-xl font-medium">
                Saved Recipes
            </div>
            <div className="collapse-content">
                <ul>
                    {
                        Array.isArray(savedRecipes) && savedRecipes.length > 0
                            ? savedRecipes.map(recipe => <li key={recipe.id}>{recipe.name}</li>)
                            : <p>This user hasn't got any saved recipes</p>
                    }
                </ul>
            </div>
        </div>
    );
}

export default SavedRecipes;
