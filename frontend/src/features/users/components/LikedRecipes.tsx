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
        <div>
            <p>Liked Recipes:
                {
                    Array.isArray(likedRecipes) && likedRecipes.length > 0
                        ? likedRecipes.map(recipe => <p key={recipe.id}>{recipe.name}</p>)
                        : <p>No liked recipes</p>
                }
            </p>

        </div>
    );
}

export default LikedRecipes;
