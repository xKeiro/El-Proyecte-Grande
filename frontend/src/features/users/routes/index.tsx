import { Route, Routes } from 'react-router-dom';
import { CurrentUser } from './User';

export const UsersRoutes = () => {
  return (
    <Routes>
      <Route path="/users/:id" element={<CurrentUser />} />
    </Routes>
  );
};
