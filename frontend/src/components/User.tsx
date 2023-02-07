import { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';

const User = () => {
    const { id } = useParams();
    const [userData, setUserData] = useState<any>({});

    useEffect(() => {
        //fetch user data
        fetchUserData();
        async function fetchUserData() {
            const res = await fetch(`https://localhost:7161/api/users/${id}`);
            const data = await res.json();
            setUserData(data);
            console.log(data)
        }
    }, [id]);

    return (
        <div>
            {userData ? (<div className="card w-100 bg-primary text-primary-content">
                <div className="card-body">
                    <h2 className="card-title">{userData.username}</h2>
                    <p>{userData.emailAddress}</p>
                    <p>Liked Recipes:</p>
                    <p>Saved Recipes:</p>
                </div>
            </div>)

                : 'Loading...'}
        </div>
    );
}

export default User;
