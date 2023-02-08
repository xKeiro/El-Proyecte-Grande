import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { fetchSavedRecipes } from '../api/getSavedRecipesByUser';
import { Link } from 'react-router-dom';

const SavedRecipes = () => {
    const [savedRecipes, setSavedRecipes] = useState<any>({});
    const { id } = useParams();


    useEffect(() => {
        const fetchData = async () => {
            const data = await fetchSavedRecipes(id || "");
            setSavedRecipes(data);
            console.log(data);
        };
        fetchData();
    }, [id]);

    return (

        <div tabIndex={0} className="collapse collapse-arrow w-2/15">
            <input type="checkbox" />
            <div className="collapse-title text-xl font-medium">
                Saved Recipes {Array.isArray(savedRecipes) && savedRecipes.length > 0 ? `(${savedRecipes.length})` : "(0)"}
            </div>
            <div className="collapse-content">
                <ul>
                    {
                        Array.isArray(savedRecipes) && savedRecipes.length > 0
                            ? savedRecipes.map(recipe => <li key={recipe.id}><Link to={`/recipes/` + recipe.id}>{recipe.name}</Link></li>)
                            : <p>This user hasn't got any saved recipes</p>
                    }
                </ul>
            </div>
        </div>
    );
}

export default SavedRecipes;
