import { RecipesRoutes } from '@/features/recipes/';
import { UsersRoutes } from '@/features/users/';
import { AdminRoutes } from '@/features/admin/';
import { RecipesRoutes } from "./features/recipes/routes";
import { UsersRoutes } from './features/users/routes';
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Navigation from "./components/Layout/nav-bar/NavBar";

import { BrowserRouter } from 'react-router-dom';

export const App = () => {
  return (
    <BrowserRouter>
      <Navigation />
        <Routes>
          <Route index path='/recipes' element={<RecipesRoutes/>} />
          <Route path='/users' element={<UsersRoutes />} />
          <Route path='/admin' element={<AdminRoutes />} />
        </Routes>
    </BrowserRouter>
  )
}
