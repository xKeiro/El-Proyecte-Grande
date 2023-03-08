import { Route, Routes } from 'react-router-dom';
import { CurrentUser } from './CurrentUser';

export const UsersRoutes = () => {
  return (
    <Routes>
      <Route path="/users/:id" element={<CurrentUser />} />
    </Routes>
  );
};
