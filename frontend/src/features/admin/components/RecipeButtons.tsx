import { Link, useNavigate } from 'react-router-dom';
import { RecipesApi } from '@/features/recipes/api/RecipesApi';

export const RecipeButtons = (props: { recipeId: number }) => {
  const navigate = useNavigate();

  async function deleteRecipe(recipeId: number) {
    let confirmed = confirm('Do you really want to delete this item?');
    if (confirmed) {
      await RecipesApi.deleteById(recipeId);
      await RecipesApi.deleteRecipeImage(recipeId);
      navigate('/admin/recipes');
    }
  }

  return (
    <div className="card-actions bg-base-100 justify-end rounded-box">
      {/* <button title="Edit recipe" className="btn btn-square btn-ghost">
        <Link key={props.recipeId} to={`/admin/recipes/${props.recipeId}/edit`}>
          <svg
            xmlns="http://www.w3.org/2000/svg"
            className="h-7 w-7"
            viewBox="0 0 24 24"
            fill="none"
            stroke="currentColor"
            strokeWidth="2"
            strokeLinecap="round"
            strokeLinejoin="round"
          >
            <path d="M20 14.66V20a2 2 0 0 1-2 2H4a2 2 0 0 1-2-2V6a2 2 0 0 1 2-2h5.34"></path>
            <polygon points="18 2 22 6 12 16 8 16 8 12 18 2"></polygon>
          </svg>
        </Link>
      </button> */}
      <button
        title="Delete recipe"
        className="btn btn-square btn-ghost"
        onClick={() => deleteRecipe(props.recipeId)}
      >
        <svg
          xmlns="http://www.w3.org/2000/svg"
          className="h-7 w-7"
          viewBox="0 0 24 24"
          fill="none"
          stroke="currentColor"
          strokeWidth="2"
          strokeLinecap="round"
          strokeLinejoin="round"
        >
          <polyline points="3 6 5 6 21 6"></polyline>
          <path d="M19 6v14a2 2 0 0 1-2 2H7a2 2 0 0 1-2-2V6m3 0V4a2 2 0 0 1 2-2h4a2 2 0 0 1 2 2v2"></path>
          <line x1="10" y1="11" x2="10" y2="17"></line>
          <line x1="14" y1="11" x2="14" y2="17"></line>
        </svg>
      </button>
    </div>
  );
};
