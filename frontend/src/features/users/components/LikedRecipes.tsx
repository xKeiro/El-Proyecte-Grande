import { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { fetchLikedRecipes } from '../api/getLikedRecipesByUser';
import { Link } from 'react-router-dom';
import { TRecipe } from '@/features/recipes';
import { recipesSchema } from '@/features/recipes';


const LikedRecipes = () => {
    const [likedRecipes, setLikedRecipes] = useState<TRecipe[]>([]);
    const { id } = useParams();

    useEffect(() => {
        const fetchData = async () => {
          const data = await fetchLikedRecipes(id || '');
          const result = recipesSchema.safeParse(data);
          if (result.success) {
            setLikedRecipes(data);
          } else {
            console.log(result.error.issues);
          }
        };
        fetchData();
      }, [id]);

    return (
        
        <div tabIndex={0} className="collapse collapse-arrow w-2/15 bg-base-300 rounded">
            <input type="checkbox" aria-label="Search" />
            <div className="collapse-title text-xl font-medium">
            Liked Recipes{' '}
            {Array.isArray(likedRecipes) && likedRecipes.length > 0 ? `(${likedRecipes.length})` : "(0)"}
            </div>
            <div className="collapse-content bg-base-200 grid grid-columns-1 align-middle">
                <ul className='align-middle pt-3'>
                    {
                        Array.isArray(likedRecipes) && likedRecipes.length > 0
                            ? likedRecipes.map(recipe => <li key={recipe.id}><Link to={`/recipes/` + recipe.id}>{recipe.name}</Link></li>)
                            : <li>This user doesn't have any liked recipes</li>
                    }
                </ul>
            </div>
        </div>
    );
}

export default LikedRecipes;
