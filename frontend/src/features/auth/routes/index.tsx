import React from "react";
import { Route, Routes } from 'react-router-dom';
import { Login } from './Login';
import { Register } from './Register';

export const AuthRoutes = ({ username, setUsername, setIsAdmin } : {
    username : string | null,
    setUsername : React.Dispatch<React.SetStateAction<string | null>>,
    setIsAdmin : React.Dispatch<React.SetStateAction<boolean>> }) => {

    return (
      <Routes>
        <Route index path="/login" element={<Login loggedInUsername={username} setLoggedInUsername={setUsername} setIsAdmin={setIsAdmin} />} />
        <Route path="/register" element={<Register loggedInUsername={username} />}></Route>
      </Routes>
    );
  };