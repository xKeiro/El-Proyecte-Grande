import React, { useEffect, useState } from 'react';
import axios, * as others from 'axios';
import { allUsers } from '../api/getUsers';
import { Link } from 'react-router-dom';


const Users = () => {

    const [users, setUsers] = useState<any[]>([]);

    useEffect(() => {
        const fetchUsers = async () => {
            const data = await allUsers();
            setUsers(data);
        };
        fetchUsers();
    }, []);

    /*     const[usersData, setUsersData] = useState<any[]>([]);
    
        useEffect(()=>{
            //fetch user data
            fetchUserData();
            async function fetchUserData(){
                const res = await axios.get(`https://localhost:7161/api/users`);
                setUsersData(res.data);
            }
        }, []) */

    return (
        <div className='flex items-center justify-center py-14'>
        <div className='overflow-x-auto w-9/12'>
            <table className="table table-normal w-full">
                <thead>
                    <tr>
                        <th>User Name</th>
                        <th>Email</th>
                        <th>Admin</th>
                    </tr>
                </thead>
                <tbody>
                    {users.map(user =>
                        <tr className="hover" key={user.id}>

                            <td><Link to={`/users/` + user.id}>{user.username}</Link></td>
                            <td>{user.emailAddress}</td>
                            <td>{user.isAdmin ? "Admin":"-"}</td>

                        </tr>
                    )}
                </tbody>
            </table>
        </div>
        </div>);
}

export default Users;
