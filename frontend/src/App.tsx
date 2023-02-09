import { RecipesRoutes } from "./features/recipes/routes";
import { UsersRoutes } from './features/users/routes';
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Navigation from "./components/Layout/nav-bar/NavBar";


export const App = () =>{
  return (
    <BrowserRouter>
      <Navigation />
        <Routes>
          <Route index path='/' element={<RecipesRoutes/>} />
          <Route path='/users' element={<UsersRoutes/>} />
        </Routes>
    </BrowserRouter>
  )
}
