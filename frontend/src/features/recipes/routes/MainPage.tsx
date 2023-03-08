import { useRef, useState } from 'react';
import { RecipeFilter } from '../components/RecipeFilter';
import { TRecipe } from '../types';
import { FilteredRecipe } from '../components/FilteredRecipe';

export const MainPage = () => {

  const [showFilteredRecipe, setShowFilteredRecipe] = useState(false);
  const [filteredRecipes, setFilteredRecipes] = useState<TRecipe[]>([]);
  const firstTime = useRef<Boolean>(true);

  function handleData(data: TRecipe[]) {
    setFilteredRecipes(data);
    setShowFilteredRecipe(true);
  }
  function scrollTo(element: HTMLDivElement | null) {
    if (firstTime.current) {
      firstTime.current = false;
    }
    else {
      element?.scrollIntoView({ behavior: 'smooth', });
    }
  }

  return (
    <div>
      <div className="grid grid-cols-1 pb-6">
        <div className='sm:container mx-auto'>
          <RecipeFilter sendData={handleData} />
        </div>
        <div className="text-right justify-content-center">
          {showFilteredRecipe
            ? <div ref={(element) => scrollTo(element)}><FilteredRecipe recipes={filteredRecipes} /></div>
            : <div className="text-center">Loading the recipes...</div>}
        </div>
      </div>
    </div>
  );
};