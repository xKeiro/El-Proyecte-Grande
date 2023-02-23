import { RecipeLeftSideSearch } from '../components/RecipeLeftSideSearch';
import { FilteredRecipe } from './FilteredRecipe';
import { useState } from 'react';
import { TRecipe } from '../types';
import axios from 'axios';
import { RecipesApi } from '../api/RecipesApi';
import { AllRecipes } from './AllRecipes';

export const MainPage = () => {

  return (
    <RecipeLeftSideSearch />
  );
};