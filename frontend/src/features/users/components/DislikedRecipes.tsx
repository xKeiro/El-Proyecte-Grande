import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { Link } from 'react-router-dom';
import { TRecipe } from '@/features/recipes';
import { recipesSchema } from '@/features/recipes';
import { UsersApi } from '../api/UsersApi';

const DislikedRecipes = ({ id } : { id : number | undefined }) => {
  const [dislikedRecipes, setDislikedRecipes] = useState<TRecipe[]>([]);

  useEffect(() => {
    const fetchData = async () => {
        if (id) {
            const data = await UsersApi.getDislikedRecipes(id);
            const result = recipesSchema.safeParse(data);
            if (result.success) {
                setDislikedRecipes(data);
            } else {
                console.log(result.error.issues);
            }
        }
    };
    fetchData();
  }, [id]);

  return (
    <div tabIndex={0} className="collapse collapse-arrow w-2/15 bg-base-300 rounded">
      <input type="checkbox" aria-label="Search"/>
      <div className="collapse-title text-xl font-medium">
        Disliked Recipes{' '}
        {Array.isArray(dislikedRecipes) && dislikedRecipes.length > 0
          ? `(${dislikedRecipes.length})`
          : '(0)'}
      </div>
      <div className="collapse-content bg-base-200 grid grid-columns-1 align-middle">
        <ul className="align-middle pt-3">
          {Array.isArray(dislikedRecipes) && dislikedRecipes.length > 0 ? (
            dislikedRecipes.map((recipe) => (
              <li key={recipe.id}>
                <Link to={`/recipes/` + recipe.id}>{recipe.name}</Link>
              </li>
            ))
          ) : (
            <li>This user doesn't have any disliked recipes</li>
          )}
        </ul>
      </div>
    </div>
  );
};

export default DislikedRecipes;
