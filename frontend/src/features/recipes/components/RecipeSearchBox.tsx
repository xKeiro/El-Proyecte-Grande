import React from "react";

export const RecipeSearchBox = () => {
  return (
    <input
      type="search"
      placeholder="Search for a recipe"
      className="text-center text-2xl w-96 h-16 bg-base-300 p-2 rounded-lg drop-shadow-xl transition ease-in-out duration-200 hover:animate-none hover:scale-105"
    />
  );
};