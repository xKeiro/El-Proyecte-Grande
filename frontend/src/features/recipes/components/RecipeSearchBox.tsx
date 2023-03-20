export const RecipeSearchBox = ({ searchTerm, setSearchTerm, handleRecipeSearch } :
                                    { searchTerm: string, setSearchTerm: React.Dispatch<React.SetStateAction<string>>, handleRecipeSearch : any }) => {

  const searchField = (document.getElementById("search-field") as HTMLInputElement);
  const handleSearch = () => {
    if (searchField.value.length == 0) handleRecipeSearch();
  };

  const handleEnterSearch = (event : any) => {
    if (event.key == "Enter") {
      handleRecipeSearch(searchField.value);
    }
  };

  return (
    <input
        id="search-field"
        type="search"
        placeholder="Search for a recipe"
        className="text-center text-xl w-72 sm:w-7/12 h-16 bg-base-300 rounded-box drop-shadow-xl transition ease-in-out duration-200 hover:animate-none hover:scale-105 m-3 p-3"
          onChange={handleSearch}
          onKeyUp={(e) => handleEnterSearch(e)}
    />
  );
};