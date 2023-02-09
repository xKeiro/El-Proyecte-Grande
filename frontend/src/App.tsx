import { RecipesRoutes } from '@/features/recipes/';
import { UsersRoutes } from '@/features/users/';
import { AdminRoutes } from '@/features/admin/';

import { BrowserRouter } from 'react-router-dom';

export const App = () => {
  return (
    <BrowserRouter>
      <RecipesRoutes />
      <UsersRoutes />
      <AdminRoutes />
    </BrowserRouter>
  );
};
