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
        <div tabIndex={0} className="collapse collapse-arrow w-6/12">
            <input type="checkbox" />
            <div className="collapse-title text-xl font-medium">
                Disliked Recipes
            </div>
            <div className="collapse-content">
                <ul>
                    {
                        Array.isArray(dislikedRecipes) && dislikedRecipes.length > 0
                            ? dislikedRecipes.map(recipe => <li key={recipe.id}>{recipe.name}</li>)
                            : <p>This user hasn't got any disliked recipes</p>
                    }
                </ul>
            </div>
        </div>
    );
}

export default DislikedRecipes;
