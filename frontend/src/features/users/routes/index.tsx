import { Navigate, Route, Routes } from 'react-router-dom';

import { Users } from './Users';
import { CurrentUser } from './User';

export const UsersRoutes = () => {
  return (
    <Routes>
      <Route path="/users" element={<Users />} />
      <Route path="/users/:id" element={<CurrentUser />} />
    </Routes>
  );
};