import { Route, Routes } from 'react-router-dom';
import { CurrentUser } from './CurrentUser';

export const UsersRoutes = ({ isAdmin } : { isAdmin : boolean }) => {
  return (
    <Routes>
      <Route path="/users/:id" element={<CurrentUser isAdmin={isAdmin} />} />
    </Routes>
  );
};
