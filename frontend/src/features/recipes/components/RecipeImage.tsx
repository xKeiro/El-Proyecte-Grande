import { API_URL } from "@/config";
import axios from "axios";
import { useState, useEffect } from "react";

export const RecipeImage = (props: { id: number, name : string, size?: { width: number, height: number } }) => {
    const [imageData, setImageData] = useState("");

    useEffect(() => {
        axios.get(`${API_URL}/ImageUpload/${props.id}`, { responseType: 'blob' })
          .then(response => {
            const imageUrl = URL.createObjectURL(response.data);
            setImageData(imageUrl);
          })
          .catch(error => {
            console.log(error);
          });
      }, [props.id]);

    let { width, height } = props.size || { width: 400, height: 500 };
    return (
        <img className="rounded-lg" src={imageData} alt={props.name} title={props.name} width={width} height={height}/>
    )
}