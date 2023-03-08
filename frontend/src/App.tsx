import { BrowserRouter } from "react-router-dom";
import { RecipesRoutes } from "@/features/recipes/";
import { UsersRoutes } from '@/features/users/';
import { AdminRoutes } from "@/features/admin";
import { AuthRoutes } from "./features/auth/routes";
import { NavBar } from "./components";
import { Footer } from "./components";

export const App = () =>{

  return (
    <BrowserRouter>
      <NavBar />
          <RecipesRoutes/>
          <UsersRoutes/>
          <AdminRoutes/>
          <AuthRoutes />
      <div className="h-20">
      </div>
      <Footer />
    </BrowserRouter>
  )
}
