import { API_URL } from "@/config";
import axios from "axios";
import { useState, useEffect } from "react";
import { RecipesApi } from "../api/RecipesApi";

export const RecipeImage = (props: { id: number, name: string, size?: { width: number, height: number } }) => {
  const [imageData, setImageData] = useState("");

  useEffect(() => {
    const fetchRecipeImage = async () => {
      try {
        if (props.id) {
          const data = await RecipesApi.getRecipeImage(props.id);
          if (data) {
            const imageResult = URL.createObjectURL(data);
            setImageData(imageResult);
          }
        }
      } catch (error) {
        console.log(error);
      }
    };
    fetchRecipeImage();
  }, [props.id]);

  let { width, height } = props.size || { width: 400, height: 500 };
  return (
    <img className="rounded-lg" src={imageData} alt={props.name} title={props.name} width={width} height={height} />
  )
}