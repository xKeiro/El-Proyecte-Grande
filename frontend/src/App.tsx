import { BrowserRouter } from "react-router-dom";
import { RecipesRoutes } from "@/features/recipes/";
import { UsersRoutes } from '@/features/users/';
import { AdminRoutes } from "@/features/admin";
import { AuthRoutes } from "./features/auth/routes";
import { NavBar } from "./components";
import { Footer } from "./components";

export const App = () =>{
    const username = sessionStorage.getItem("username");
    const isAdmin = sessionStorage.getItem("isAdmin") == null ? false : sessionStorage.getItem("isAdmin") == "true";

  return (
    <BrowserRouter>
      <NavBar username={username} isAdmin={isAdmin} />
          <RecipesRoutes username={username}/>
          <UsersRoutes/>
          <AdminRoutes isAdmin={isAdmin} />
          <AuthRoutes username={username} />
      <div className="h-20">
      </div>
      <Footer />
    </BrowserRouter>
  )
}
