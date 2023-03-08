import { useState } from "react";
import { BrowserRouter } from "react-router-dom";
import { RecipesRoutes } from "@/features/recipes/";
import { UsersRoutes } from '@/features/users/';
import { AdminRoutes } from "@/features/admin";
import { AuthRoutes } from "./features/auth/routes";
import { NavBar } from "./components";
import { Footer } from "./components";

export const App = () =>{
    const [username, setUsername] = useState("");
    const [isAdmin, setIsAdmin] = useState(false);

  return (
    <BrowserRouter>
      <NavBar username={username} isAdmin={isAdmin} setUsername={setUsername} setIsAdmin={setIsAdmin} />
          <RecipesRoutes/>
          <UsersRoutes/>
          <AdminRoutes/>
          <AuthRoutes setUsername={setUsername} setIsAdmin={setIsAdmin} />
      <div className="h-20">
      </div>
      <Footer />
    </BrowserRouter>
  )
}
