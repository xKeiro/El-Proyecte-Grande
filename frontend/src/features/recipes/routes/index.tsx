import { Route, Routes } from 'react-router-dom';
import { Recipe } from './Recipe';

import { MainPage } from './MainPage';

export const RecipesRoutes = ({ username } : { username : string | null }) => {
  return (
      <div className="container bg-base-100 rounded-box grid grid-cols-1 mx-auto shadow-2xl">
        <Routes>
          <Route index path="/" element={<MainPage />} />
          <Route path="/recipes/:id" element={<Recipe username={username} />}></Route>
        </Routes>
      </div>
  );
};
