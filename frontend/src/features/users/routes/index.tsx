import { Route, Routes } from 'react-router-dom';
import { CurrentUser } from './User';
import { UserLogin } from './UserLogin';
import Register from '../components/Register';

export const UsersRoutes = () => {
  return (
    <Routes>
      <Route path="/users/:id" element={<CurrentUser />} />
      <Route path="/login" element={<UserLogin />} />
      <Route path="/register" element={<Register />} />
    </Routes>
  );
};
