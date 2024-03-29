import { useEffect, useState } from 'react';
import { Link, Navigate } from 'react-router-dom';
import { getUsers } from '../api/UsersApi';
import { TUser } from '@/features/users';

export const Users = ({ isAdmin } : { isAdmin : boolean }) => {
  const [users, setUsers] = useState<TUser[]>([]);

  useEffect(() => {
    const fetchData = async () => {
      const result = await getUsers();
      setUsers(result);
    };
    fetchData();
  }, []);
  if (isAdmin)
  return (
    <div className="overflow-x-auto mx-auto my-6">
      <table className="table w-full">
        <thead>
          <tr>
            <th>Username</th>
            <th className="min-[320px]:max-sm:hidden">Name</th>
            <th className="min-[320px]:max-sm:hidden">Email</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {users.map((user) => (
            <tr key={user.id}>
              <td>{user.username}</td>
              <td className="min-[320px]:max-sm:hidden">
                {(user.firstName == null ? '' : user.firstName) +
                  (user.firstName != null && user.lastName != null ? ' ' : '-') +
                  (user.lastName == null ? '' : user.lastName)}
              </td>
              <td className="min-[320px]:max-sm:hidden">{user.emailAddress}</td>
              <td>
                <Link to={`/users/${user.id}`} className="btn btn-square btn-ghost">
                  <svg
                    xmlns="http://www.w3.org/2000/svg"
                    className="h-5 w-5"
                    viewBox="0 0 24 24"
                    fill="none"
                    stroke="currentColor"
                    strokeWidth="2"
                    strokeLinecap="round"
                    strokeLinejoin="round"
                  >
                    <path d="M20 21v-2a4 4 0 0 0-4-4H8a4 4 0 0 0-4 4v2"></path>
                    <circle cx="12" cy="7" r="4"></circle>
                  </svg>
                </Link>
                {/* <button className="btn btn-square btn-ghost">
                  <svg
                    xmlns="http://www.w3.org/2000/svg"
                    className="h-5 w-5"
                    viewBox="0 0 24 24"
                    fill="none"
                    stroke="currentColor"
                    strokeWidth="2"
                    strokeLinecap="round"
                    strokeLinejoin="round"
                  >
                    <path d="M20 14.66V20a2 2 0 0 1-2 2H4a2 2 0 0 1-2-2V6a2 2 0 0 1 2-2h5.34"></path>
                    <polygon points="18 2 22 6 12 16 8 16 8 12 18 2"></polygon>
                  </svg>
                </button>
                <button className="btn btn-square btn-ghost">
                  <svg
                    xmlns="http://www.w3.org/2000/svg"
                    className="h-5 w-5"
                    viewBox="0 0 24 24"
                    fill="none"
                    stroke="currentColor"
                    strokeWidth="2"
                    strokeLinecap="round"
                    strokeLinejoin="round"
                  >
                    <polyline points="3 6 5 6 21 6"></polyline>
                    <path d="M19 6v14a2 2 0 0 1-2 2H7a2 2 0 0 1-2-2V6m3 0V4a2 2 0 0 1 2-2h4a2 2 0 0 1 2 2v2"></path>
                    <line x1="10" y1="11" x2="10" y2="17"></line>
                    <line x1="14" y1="11" x2="14" y2="17"></line>
                  </svg>
                </button> */}
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
  return (<Navigate to="/unauthorized" />);
};
