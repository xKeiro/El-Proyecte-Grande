import { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { Link } from 'react-router-dom';
import { TRecipe } from '@/features/recipes';
import { recipesSchema } from '@/features/recipes';
import { UsersApi } from '../api/UsersApi';

const SavedRecipes = ({ id } : { id : number | undefined }) => {
  const [savedRecipes, setSavedRecipes] = useState<TRecipe[]>([]);

  useEffect(() => {
    const fetchData = async () => {
        if (id) {
            const data = await UsersApi.getSavedRecipes(id);
            const result = recipesSchema.safeParse(data);
            if (result.success) {
                setSavedRecipes(data);
            } else {
                console.log(result.error.issues);
            }
        }
    };
    fetchData();
  }, [id]);

  return (
    <div tabIndex={0} className="collapse collapse-arrow w-2/15 bg-base-300 rounded">
      <input type="checkbox" aria-label="Search" />
      <div className="collapse-title text-xl font-medium">
        Saved Recipes{' '}
        {Array.isArray(savedRecipes) && savedRecipes.length > 0 ? `(${savedRecipes.length})` : "(0)"}
      </div>
      <div className="collapse-content bg-base-200 grid grid-columns-1 align-middle">
        <ul className='align-middle pt-3'>
          {
            Array.isArray(savedRecipes) && savedRecipes.length > 0
              ? savedRecipes.map(recipe => <li key={recipe.id}><Link to={`/recipes/` + recipe.id}>{recipe.name}</Link></li>)
              : <li>This user doesn't have any saved recipes</li>
          }
        </ul>
      </div>
    </div>
  );
}

export default SavedRecipes;
