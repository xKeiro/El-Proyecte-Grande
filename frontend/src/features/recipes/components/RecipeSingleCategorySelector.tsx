import { Category } from '@/features/categories';
import { CategoriesEnum } from '@/features/categories';

type props = {
  categories: Category[];
  categoryName: CategoriesEnum;
  selectedCategories: Category[];
  handleCategorySelection: (category: Category) => void;
  handleCategorySelectionRemoval: (category: Category) => void;
};

export const RecipeSingleCategorySelector: React.FC<props> = ({
  categories,
  categoryName,
  selectedCategories,
  handleCategorySelection,
  handleCategorySelectionRemoval,
}) => {
  const handleCategoryChange = (e: React.ChangeEvent<HTMLSelectElement>) => {
    const selectedCategory = categories.find(
      (category) => category.id === parseInt(e.target.value)
    );
    if (selectedCategory) {
      handleCategorySelection(selectedCategory);
      e.target.value = 'none';
    }
  };
  const handleCategoryRemoval = (e: React.MouseEvent<HTMLSpanElement>) => {
    const selectedCategory = selectedCategories.find(
      (category) => category.id === parseInt(e.currentTarget.dataset.id!)
    );
    if (selectedCategory) {
      handleCategorySelectionRemoval(selectedCategory);
    }
  };

  return (
    <div className="bg-primary w-full grid grid-cols-1 gap-4 justify-items-center bg-base-200 rounded-lg drop-shadow-xl p-2 content-start items-start">
      <div className="text-2xl mt-2 transition ease-in-out duration-200 hover:animate-none hover:scale-105">
        {categoryName}
      </div>
      <div className="grid grid-cols-1 items-center content-start items-start">
        <select
          name={categoryName}
          title={categoryName}
          className="select drop-shadow-xl font-bold"
          onChange={handleCategoryChange}
        >
          <option value="none" selected disabled>
            Select an Option
          </option>
          {categories.map((category) => (
            <option value={category.id}>{category.name}</option>
          ))}
        </select>
      </div>
      <div className="flex flex-wrap gap-1">
        {selectedCategories.map((selectedCategory) => (
          <span
            className="rounded-xl border bg-base-100 p-2 drop-shadow-xl hover:bg-error cursor-pointer"
            data-id={selectedCategory.id}
            onClick={handleCategoryRemoval}
          >
            {selectedCategory.name}
          </span>
        ))}
      </div>
    </div>
  );
};
