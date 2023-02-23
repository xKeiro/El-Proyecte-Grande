import { RecipeFilter } from './RecipeFilter';
import { TRecipe } from '../types';
import { AllRecipes } from '../routes/AllRecipes';
import { FilteredRecipe } from '../routes/FilteredRecipe';
import { useState } from 'react';

export const RecipeLeftSideSearch = () => {

  const [showFilteredRecipe, setShowFilteredRecipe] = useState(false);
  const [filteredRecipes, setFilteredRecipes] = useState<TRecipe[]>([]);

  function handleData(data: TRecipe[]) {
    setFilteredRecipes(data);
    setShowFilteredRecipe(true)
  }

  return (

    <div className="grid grid-cols-3 md:grid-cols-3">
      <div className="order-2 md:order-1 px-4">
        <ul className="menu p-4 w-80 bg-base-200 text-base-content w-2/3 rounded-xl">
          <div className='sm:container mx-auto'>
            <RecipeFilter sendData={handleData} />
          </div>
        </ul>
      </div>
      <div className="order-1 md:order-2 text-right col-span-2 justify-content-center">
        {showFilteredRecipe ? <FilteredRecipe recipes={filteredRecipes} /> : <AllRecipes />}
      </div>
    </div>
  );


};