import { User } from '../components/User';

export const CurrentUser = ({ isAdmin } : { isAdmin : boolean }) => {
    return (
        <User isAdmin={isAdmin}/>
    );
  };