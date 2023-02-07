import { Navigate, Route, Routes } from 'react-router-dom';

import { MainPage } from './MainPage';

export const RecipesRoutes = () => {
  return (
    <Routes>
      <Route path="" element={<MainPage />} />
    </Routes>
  );
};