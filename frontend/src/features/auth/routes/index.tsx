import React from "react";
import { Route, Routes } from 'react-router-dom';
import { Login } from './Login';
import { Register } from './Register';

export const AuthRoutes = ({ username } : { username : string | null }) => {
    return (
      <Routes>
        <Route index path="/login" element={<Login loggedInUsername={username} />} />
        <Route path="/register" element={<Register username={username} />}></Route>
      </Routes>
    );
  };