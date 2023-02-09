import { Navigate, Route, Routes } from 'react-router-dom';
import { Recipe } from './Recipe';

import { MainPage } from './MainPage';

export const RecipesRoutes = () => {
  return (
    <Routes>
      <Route index path="/" element={<MainPage />} />
      <Route path="/recipes/:id" element={<Recipe />}></Route>
    </Routes>
  );
};
