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
        <div>
            <p>Saved Recipes:</p>
            {
                Array.isArray(savedRecipes) && savedRecipes.length > 0
                    ? savedRecipes.map(recipe => <p key={recipe.id}>{recipe.name}</p>)
                    : <p>No liked recipes</p>
            }
        </div>
    );
}

export default SavedRecipes;
