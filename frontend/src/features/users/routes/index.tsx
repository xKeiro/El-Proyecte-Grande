import { Route, Routes } from 'react-router-dom';
import { CurrentUser } from './User';
import { UserLogin } from '../../auth/routes/UserLogin';
import Register from '../../auth/components/Register';

export const UsersRoutes = () => {
  return (
    <Routes>
      <Route path="/users/:id" element={<CurrentUser />} />
    </Routes>
  );
};
