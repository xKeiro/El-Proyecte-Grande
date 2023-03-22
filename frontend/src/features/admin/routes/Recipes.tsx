import { useEffect, useState } from 'react';
import { Link, Navigate } from 'react-router-dom';
import { RecipesApi } from '@/features/recipes/api/RecipesApi';
import { TRecipe, TRecipesFilter, TRecipesWithPagination } from '@/features/recipes';
import { RecipeSearchBox } from "@/features/recipes/components/RecipeSearchBox";
import { RecipeAddNew } from '../components/RecipeAddNew';
import InfiniteScroll from 'react-infinite-scroller';
import ReactDOM from 'react-dom';

export const Recipes = ({ isAdmin }: { isAdmin: boolean }) => {
  const [filteredRecipesWithPagination, setFilteredRecipesWithPagination] = useState<TRecipesWithPagination | null>(null);
  const [searchTerm, setSearchTerm] = useState<string>('');
  const [currentFilter, setCurrentFilter] = useState<TRecipesFilter | null>(null);

  useEffect(() => {
    const fetchData = async () => {
      handleSearch();
    };
    fetchData();
  }, []);

  const handleSearch = async (searchString: string = "") => {
    const filter: TRecipesFilter = {
      cuisineIds: [],
      dietIds: [],
      ingredientIds: [],
      mealTimeIds: [],
      dishTypeIds: [],
      searchString: searchString,
      preparationMaxDifficulty: null,
      maxNotOwnedIngredients: null,
      page: 1,
      recipesPerPage: 5
    }
    setCurrentFilter(filter);
    const recipesList = await RecipesApi.filterRecipes(filter);
    setFilteredRecipesWithPagination(recipesList);
  }

  async function loadMoreRecipes() {
    if (currentFilter === null) return;
    const nextFilter = currentFilter;
    nextFilter.page = currentFilter.page + 1;
    const recipesWithPagination = (await RecipesApi.filterRecipes(nextFilter));
    if (recipesWithPagination) {
      recipesWithPagination.recipes = filteredRecipesWithPagination!.recipes.concat(recipesWithPagination.recipes);
      setFilteredRecipesWithPagination(recipesWithPagination);
      setCurrentFilter(nextFilter);
    }
    else {
      const errorElement = (
        <div className="toast toast-center">
          <div className="alert alert-error">
            <div>
              <span>There was a problem!.</span>
            </div>
          </div>
        </div>
      )
      ReactDOM.render(errorElement, document.body);
    }

  }

  if (isAdmin)
    return (
      <div id="recipes-container" className="text-base-content">
        <div className='text-center'>
          <RecipeSearchBox searchTerm={searchTerm} setSearchTerm={setSearchTerm} handleRecipeSearch={handleSearch} />
        </div>

        <InfiniteScroll
          pageStart={0}
          loadMore={loadMoreRecipes}
          hasMore={filteredRecipesWithPagination?.nextPage != null}
          loader={<div className="loader" key={0}>Loading ...</div>}
        >
          <div className="grid grid-cols-4 gap-5 text-center py-5">
            {filteredRecipesWithPagination?.recipes.map((recipe) => (
              <Link key={recipe.id} to={`/admin/recipes/${recipe.id}`} className="hover:underline">
                {recipe.name}
              </Link>
            ))}
          </div>
        </InfiniteScroll>


        <div className='flex justify-center mt-4'>
          <Link to="/admin/recipes/add" className="btn btn-primary">Add New Recipe</Link>
        </div>
      </div>
    );
  return (<Navigate to="/unauthorized" />)
};
