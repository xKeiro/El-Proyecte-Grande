export const RecipeSearchBox = ({ searchTerm, setSearchTerm, handleRecipeSearch } :
                                    { searchTerm: string, setSearchTerm: React.Dispatch<React.SetStateAction<string>>, handleRecipeSearch : any }) => {

  const searchField = (document.getElementById("search-field") as HTMLInputElement);
  const handleSearch = () => {
    if (searchField.value.length == 0) handleRecipeSearch();
    // setSearchTerm(searchField.value);
  };

  const handleEnterSearch = (event : any) => {
    if (event.key == "Enter") {
      if (searchField.value.length == 1) alert("You have to write 0 or at least 2 characters!");
      else handleRecipeSearch(searchField.value);
    }
  };

  return (
    <input
        id="search-field"
        type="search"
        placeholder="Search for a recipe"
        className="text-center text-xl w-70 h-16 bg-base-300 rounded-box drop-shadow-xl transition ease-in-out duration-200 hover:animate-none hover:scale-105 m-3 p-3"
          // value={searchTerm}
          onChange={handleSearch}
          onKeyUp={(e) => handleEnterSearch(e)}
    />
  );
};