import { Route, Routes } from 'react-router-dom';
import Login from '../components/Login';
import Register from '../components/Register';

export const AuthRoutes = () => {
    return (
      <Routes>
        <Route index path="/login" element={<Login />} />
        <Route path="/register" element={<Register />}></Route>
      </Routes>
    );
  };