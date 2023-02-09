import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { fetchDislikedRecipes } from '../api/getDislikedRecipesByUser';
import { Link } from 'react-router-dom';
import { TRecipe } from '@/features/recipes';
import { recipesSchema } from '@/features/recipes';

const DislikedRecipes = () => {
  const [dislikedRecipes, setDislikedRecipes] = useState<TRecipe[]>([]);
  const { id } = useParams();

  useEffect(() => {
    const fetchData = async () => {
      const data = await fetchDislikedRecipes(id || '');
      console.log(data);
      const result = recipesSchema.safeParse(data);
      console.log(result);
      if (result.success) {
        setDislikedRecipes(data);
        console.log(data);
      } else {
        console.log(result.error.issues);
      }
    };
    fetchData();
  }, [id]);

  return (
    <div tabIndex={0} className="collapse collapse-arrow w-2/15 bg-base-300 rounded">
      <input type="checkbox" />
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
            <p>This user doesn't have any disliked recipes</p>
          )}
        </ul>
      </div>
    </div>
  );
};

export default DislikedRecipes;
