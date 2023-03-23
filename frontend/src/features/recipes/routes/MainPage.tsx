import { createElement, useEffect, useRef, useState } from 'react';
import { RecipeFilter } from '../components/RecipeFilter';
import { TRecipe, TRecipesFilter, TRecipesWithPagination } from '../types';
import { FilteredRecipe } from '../components/FilteredRecipe';
import ReactDOM from 'react-dom';
import InfiniteScroll from 'react-infinite-scroller';
import { RecipesApi } from '../api/RecipesApi';

export const MainPage = () => {
  const [filteredRecipesWithPagination, setFilteredRecipesWithPagination] = useState<TRecipesWithPagination | null>(null);
  const [currentFilter, setCurrentFilter] = useState<TRecipesFilter | null>(null);
  const [showToTopButton, setShowToTopButton] = useState(false);
  const [scrollToRecipe, setScrollToRecipe] = useState<HTMLDivElement | null>(null);
  const firstTime = useRef<Boolean>(true);

  async function handleFilteringResult(filter: TRecipesFilter) {
    const recipesWithPagination = (await RecipesApi.filterRecipes(filter));
    if (recipesWithPagination) {
      setFilteredRecipesWithPagination(recipesWithPagination);
      setCurrentFilter(filter)
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

  function scrollTo(element: HTMLDivElement | null) {
    if (firstTime.current) {
      firstTime.current = false;
    }
    else {
      element?.scrollIntoView({ behavior: 'smooth', });
    }
  }
  const scrollToTop = () => {
    window.scrollTo({
      top: 0,
      behavior: 'smooth',
    });
  };
  useEffect(() => {
    window.addEventListener("scroll", () => {
      if (window.pageYOffset > 300) {
        setShowToTopButton(true);
      } else {
        setShowToTopButton(false);
      }
    });
  }, []);
  useEffect(() => {
    scrollTo(scrollToRecipe);
  }, [filteredRecipesWithPagination]);

  return (
    <div>
      <div className="grid grid-cols-1 pb-6">
        <div className='sm:container mx-auto'>
          <RecipeFilter handleFilteringResult={handleFilteringResult} />
        </div>
        <div className="text-right justify-content-center">
          {filteredRecipesWithPagination !== null
            ? <div ref={(element) => setScrollToRecipe(element)}>
              <InfiniteScroll
                pageStart={0}
                loadMore={loadMoreRecipes}
                hasMore={filteredRecipesWithPagination.nextPage != null}
                loader={<div className="loader" key={0}>Loading ...</div>}
              >
                <FilteredRecipe recipes={filteredRecipesWithPagination.recipes} />
              </InfiniteScroll>

            </div>
            : <div className="text-center">Loading the recipes...</div>}
        </div>
      </div>
      {showToTopButton && (<button className='btn btn-circle fixed right-8 bottom-36 md:bottom-20 w-16 h-16 text-2xl text-base-content outline-base-content glass' type='button' title='Jump back to the top of the page' onClick={scrollToTop}><svg xmlns="http://www.w3.org/2000/svg" width="36" height="36" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round"><path d="M12 19V6M5 12l7-7 7 7" /></svg></button>)}
    </div>
  );
};