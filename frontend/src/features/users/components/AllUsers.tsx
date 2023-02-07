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
            console.log(data);
        };
        fetchUsers();
    }, []);

    /*     const[usersData, setUsersData] = useState<any[]>([]);
    
        useEffect(()=>{
            //fetch user data
            fetchUserData();
            async function fetchUserData(){
                const res = await axios.get(`https://localhost:7161/api/users`);
                console.log(res.data);
                setUsersData(res.data);
            }
        }, []) */

    return (
        <div className='overflow-x-auto'>
            <table className="table table-normal">
                <thead>
                    <tr>
                        <th>User Name</th>
                        <th>Email</th>
                    </tr>
                </thead>
                <tbody>
                    {users.map(user =>
                        <tr key={user.id}>

                            <td><Link to={`/users/` + user.id}>{user.username}</Link></td>
                            <td>{user.emailAddress}</td>

                        </tr>
                    )}
                </tbody>
            </table>
        </div>);
}

export default Users;
