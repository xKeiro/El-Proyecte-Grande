import { RecipeLeftSideSearch } from '../components/RecipeLeftSideSearch';
import { FilteredRecipe } from './FilteredRecipe';
import { useState } from 'react';
import { TRecipe } from '../types';
import axios from 'axios';
import { RecipesApi } from '../api/RecipesApi';
import { AllRecipes } from './AllRecipes';

export const MainPage = () => {
  const [filteredRecipes, setFilteredRecipes] = useState<TRecipe[]>([]);
  console.log(filteredRecipes)

  function handleData(data: TRecipe[]) {
    console.log("Received data:", data);
    setFilteredRecipes(data);
  }

  return (
    <div>
      <RecipeLeftSideSearch setFilteredRecipes={setFilteredRecipes} />
      <FilteredRecipe recipes={filteredRecipes}  />

    </div>
  );
};