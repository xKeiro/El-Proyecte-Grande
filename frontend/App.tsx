import React from 'react';
import { Routes, Route } from 'react-router-dom';

import './src/App.css'
import Navigation from "./src/components/nav-bar/NavBar"
import MainPage from "./src/components/main-page/MainPage"


const App = () => {
  return (
    <Routes>
      <Route path='/' element={<Navigation />}>
        <Route index element={<MainPage />} />
      </Route>
    </Routes>
);
};

export default App;
