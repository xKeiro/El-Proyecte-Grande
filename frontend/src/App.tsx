import { RecipesRoutes } from '@/features/recipes'
import { UsersRoutes } from './features/users/routes';
import { BrowserRouter, Routes, Route } from "react-router-dom";


export const App = () =>{
  return (
      <BrowserRouter>
        <RecipesRoutes/>
        <UsersRoutes/>
      </BrowserRouter>
  )
}