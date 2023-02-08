import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { fetchDislikedRecipes } from '../api/getDislikedRecipesByUser';

const DislikedRecipes = () => {

    const [dislikedRecipes, setDislikedRecipes] = useState<any>({});
    const { id } = useParams();

    useEffect(() => {
        const fetchData = async () => {
            const data = await fetchDislikedRecipes(id);
            setDislikedRecipes(data);
            console.log(data);
        };
        fetchData();
    }, [id]);
    return (
        <div>
            <p>Disliked Recipes:
                {
                    Array.isArray(dislikedRecipes) && dislikedRecipes.length > 0
                        ? dislikedRecipes.map(recipe => <p key={recipe.id}>{recipe.name}</p>)
                        : <p>No liked recipes</p>
                }
            </p>

        </div>
    );
}

export default DislikedRecipes;
