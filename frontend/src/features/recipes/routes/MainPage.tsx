import { RecipeLeftSideSearch } from '../components/RecipeLeftSideSearch';
import { FilteredRecipe } from './FilteredRecipe';
import { useState } from 'react';
import { TRecipe } from '../types';
import axios from 'axios';
import { RecipesApi } from '../api/RecipesApi';
import { AllRecipes } from './AllRecipes';

export const MainPage = () => {
  const [filteredRecipes, setFilteredRecipes] = useState<TRecipe[]>([]);
  const [showFilteredRecipe, setShowFilteredRecipe] = useState(false);

  function handleData(data: TRecipe[]) {
    console.log("Received data:", data);
    setFilteredRecipes(data);
  }
  const handleFilteredRecipes = (data) => {
    setFilteredRecipes(data);
    setShowFilteredRecipe(true);
  };
  const showAllRecipes = () => {
    setShowFilteredRecipe(false);
  };

  return (
    <div className="flex flex-wrap">
      <div className="w-full md:w-1/2">
        <RecipeLeftSideSearch setFilteredRecipes={handleFilteredRecipes} onButtonClick={showAllRecipes} />
      </div>
      <div className="w-full md:w-1/2">
        {showFilteredRecipe ? <FilteredRecipe recipes={filteredRecipes} /> : <AllRecipes />}
      </div>
    </div>
  );
};