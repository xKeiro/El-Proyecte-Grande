import { RecipesRoutes } from '@/features/recipes'
import { BrowserRouter, Routes, Route } from "react-router-dom";


export const App = () =>{
  return (
      <BrowserRouter>
        <RecipesRoutes/>
      </BrowserRouter>
  )
}