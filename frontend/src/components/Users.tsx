import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';

const Users = () => {

  const [usersData, setUsersData] = useState<any[]>([]);

  useEffect(() => {
    //fetch user data
    fetchUserData();
    async function fetchUserData() {
      const res = await fetch(`https://localhost:7161/api/users`);
      const data = await res.json();
      setUsersData(data);
      console.log(data)
    }
  }, [])

  return (
    <div className='overflow-x-auto'>
      <h2>Users</h2>
      <table className="table table-normal">
        <thead>
          <tr>
            <th>User Name</th>
            <th>Email</th>
          </tr>
        </thead>
        <tbody>
          {usersData.map(user =>
            <tr key={user.id}>

              <td><Link to={`/users/` + user.id}>{user.username}</Link></td>
              <td>{user.emailAddress}</td>

            </tr>
          )}
        </tbody>
      </table>
    </div>
  );
}

export default Users;
