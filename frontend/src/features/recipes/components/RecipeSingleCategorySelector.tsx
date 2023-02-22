import { Category } from '@/features/categories';
import { CategoriesEnum } from '@/features/categories';
import { Ingredient } from '../../ingredients/types/index';

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
    <div className="bg-primary w-72 grid grid-cols-1 gap-4 bg-base-200 rounded-lg drop-shadow-xl p-2 content-start items-start">
      <div className="grid grid-cols-2 content-start items-start">
        <div className="text-left text-xl pl-4 mt-2 transition ease-in-out duration-200 hover:animate-none hover:scale-105">
          {categoryName}
        </div>
        <select
          name={categoryName}
          defaultValue={"default"}
          title={categoryName}
          className="select drop-shadow-xl font-bold"
          onChange={handleCategoryChange}
        >
          <option value="default" disabled>Select</option>
          {categories.map((category) => (
            <option key={category.id} value={category.id}>{category.name}</option>
          ))}
        </select>
      </div>
      <div className="flex flex-wrap gap-1 md:justify-center">
        {selectedCategories.map((selectedCategory) => (
          <span
            key={selectedCategory.id}
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
