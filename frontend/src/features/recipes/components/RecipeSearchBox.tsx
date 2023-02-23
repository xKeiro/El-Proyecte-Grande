export const RecipeSearchBox = ({ searchTerm, setSearchTerm }: { searchTerm: string, setSearchTerm: React.Dispatch<React.SetStateAction<string>> }) => {

  const handleSearch = (event: React.ChangeEvent<HTMLInputElement>) => {
    setSearchTerm(event.target.value);
  };
  return (
    <input
      type="search"
      placeholder="Search for a recipe"
          className="text-center text-l w-70 h-16 bg-base-300 p-2 rounded-lg drop-shadow-xl transition ease-in-out duration-200 hover:animate-none hover:scale-105"
          value={searchTerm}
          onChange={handleSearch}
    />
  );
};
// type="search"
// placeholder="Search for a recipe"
// className="text-center text-xl w-96 h-12 bg-base-300
// rounded-box drop-shadow-xl transition ease-in-out duration-200
// hover:animate-none hover:scale-105 m-3 p-3"