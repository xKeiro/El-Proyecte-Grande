import { useState } from "react";
import { BrowserRouter } from "react-router-dom";
import { RecipesRoutes } from "@/features/recipes/";
import { UsersRoutes } from '@/features/users/';
import { AdminRoutes } from "@/features/admin";
import { AuthRoutes } from "./features/auth/routes";
import { NavBar } from "./components";
import { Footer } from "./components";

export const App = () =>{
    const [username, setUsername] = useState(sessionStorage.getItem("username"));
    const [isAdmin, setIsAdmin] = useState(sessionStorage.getItem("isAdmin") == null ? false : sessionStorage.getItem("isAdmin") == "true");

  return (
    <BrowserRouter>
      <NavBar username={username} isAdmin={isAdmin} setUsername={setUsername} setIsAdmin={setIsAdmin} />
          <RecipesRoutes username={username}/>
          <UsersRoutes isAdmin={isAdmin}/>
          <AdminRoutes isAdmin={isAdmin} />
          <AuthRoutes username={username} setUsername={setUsername} setIsAdmin={setIsAdmin} />
      <div className="h-32 w-10" />
      <Footer />
    </BrowserRouter>
  )
}
