import { Navigate, Route, Routes } from 'react-router-dom';

import { MainPage } from './MainPage';

export const RecipesRoutes = () => {
  return (
    <Routes>
      <Route index path="/recipe" element={<MainPage />} />
    </Routes>
  );
};