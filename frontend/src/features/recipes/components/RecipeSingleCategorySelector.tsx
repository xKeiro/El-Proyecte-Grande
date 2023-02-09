import { Category } from '@/features/categories';

export const RecipeSingleCategorySelector = (
  categories: Category[],
  categoryName: string,
  selectedCategories: Category[]
) => {
  return (
    <div className="bg-primary w-full grid grid-cols-1 gap-4 justify-items-center bg-base-200 rounded-lg drop-shadow-xl p-2">
      <div className="text-2xl mt-2 transition ease-in-out duration-200 hover:animate-none hover:scale-105">
        {categoryName}
      </div>
      <div className="grid grid-cols-12 items-center">
        <select
          name={categoryName}
          title={categoryName}
          className="select drop-shadow-xl font-bold col-span-9"
        >
          {categories.map((category) => (
            <option value={category.id}>{category.name}</option>
          ))}
        </select>
        <button className="btn btn-circle btn-outline align-middle ml-2 p-2 drop-shadow-xl border-base-200 col-span-3">
          <span className="material-symbols-outlined">add</span>
        </button>
      </div>
      <div className="flex flex-wrap gap-1">
        {selectedCategories.map((selectedCategory) => (
          <span
            className="rounded-xl border bg-base-100 p-2 drop-shadow-xl"
            data-id={selectedCategory.id}
          >
            {selectedCategory.name}
          </span>
        ))}
      </div>
    </div>
  );
};
