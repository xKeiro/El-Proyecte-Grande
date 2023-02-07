import axios, * as others from 'axios';
import { useParams } from 'react-router-dom';



export const currentUser =async () => {
    const { id } = useParams();
    const res = await axios.get(`https://localhost:7161/api/${id}`);
    console.log(res.data);
    return await res.data;    
}