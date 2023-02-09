import { RecipesRoutes } from "@/features/recipes/";
import { UsersRoutes } from '@/features/users/';
import { AdminRoutes } from "@/features/admin";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import { NavBar } from "./components";
import { Footer } from "./components";

export const App = () =>{
  return (
    <BrowserRouter>
      <NavBar />
          <RecipesRoutes/>
          <UsersRoutes/>
          <AdminRoutes/>
      <div className="h-20">
      </div>
      <Footer />
    </BrowserRouter>
  )
}
