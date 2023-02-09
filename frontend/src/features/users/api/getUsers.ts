import axios, * as others from 'axios';
import { API_URL } from '@/config';



export const allUsers =async () => {
    const res = await axios.get(`${API_URL}/users`);
    console.log(res.data);
    return await res.data;    
}
