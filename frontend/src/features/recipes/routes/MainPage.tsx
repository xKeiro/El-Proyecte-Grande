import { createElement, useEffect, useRef, useState } from 'react';
import { RecipeFilter } from '../components/RecipeFilter';
import { TRecipe } from '../types';
import { FilteredRecipe } from '../components/FilteredRecipe';

export const MainPage = () => {
  const [filteredRecipes, setFilteredRecipes] = useState<TRecipe[]>([]);
  const [showToTopButton, setShowToTopButton] = useState(false);
  const [scrollToRecipe, setScrollToRecipe] = useState<HTMLDivElement | null>(null);
  const firstTime = useRef<Boolean>(true);

  function handleData(data: TRecipe[]) {
    setFilteredRecipes(data);
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
  }, [filteredRecipes]);

  return (
    <div>
      <div className="grid grid-cols-1 pb-6">
        <div className='sm:container mx-auto'>
          <RecipeFilter sendData={handleData} />
        </div>
        <div className="text-right justify-content-center">
          {filteredRecipes.length > 0
            ? <div ref={(element) => setScrollToRecipe(element)}><FilteredRecipe recipes={filteredRecipes} /></div>
            : <div className="text-center">Loading the recipes...</div>}
        </div>
      </div>
      {showToTopButton && (<button className='btn btn-circle fixed right-11 bottom-20 w-16 h-16 text-2xl text-base-content outline-base-content glass' type='button' title='Jump back to the top of the page' onClick={scrollToTop}><svg xmlns="http://www.w3.org/2000/svg" width="36" height="36" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round"><path d="M12 19V6M5 12l7-7 7 7" /></svg></button>)}
    </div>
  );
};