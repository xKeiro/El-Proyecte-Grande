import axios, * as others from 'axios';



export const allUsers =async () => {
    const res = await axios.get(`https://localhost:7161/api/users`);
    console.log(res.data);
    return await res.data;    
}
