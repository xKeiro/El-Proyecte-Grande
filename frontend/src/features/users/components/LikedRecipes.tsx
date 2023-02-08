import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { fetchLikedRecipes } from '../api/getLikedRecipesByUser';

const LikedRecipes = () => {
    const [likedRecipes, setLikedRecipes] = useState<any>({});
    const { id } = useParams();

    useEffect(() => {
        const fetchData = async () => {
            const data = await fetchLikedRecipes(id);
            setLikedRecipes(data);
            console.log(data);
        };
        fetchData();
    }, [id]);

    return (
        
        <div tabIndex={0} className="collapse collapse-arrow w-6/12">
            <input type="checkbox" />
            <div className="collapse-title text-xl font-medium">
                Liked Recipes
            </div>
            <div className="collapse-content">
                <ul>
                    {
                        Array.isArray(likedRecipes) && likedRecipes.length > 0
                            ? likedRecipes.map(recipe => <li key={recipe.id}>{recipe.name}</li>)
                            : <p>This user hasn't got any liked recipes</p>
                    }
                </ul>
            </div>
        </div>
    );
}

export default LikedRecipes;
