import { PreparationDifficulty } from '../types';

type props = {
  preparationMaxDifficulty: PreparationDifficulty | null;
  handlePreparationDifficultySelection: (preparationDifficulty: PreparationDifficulty) => void;
};

export const RecipeDifficultySelector: React.FC<props> = ({
  preparationMaxDifficulty,
  handlePreparationDifficultySelection,
}) => {
  const handlePreparationDifficultyChange = (e: React.ChangeEvent<HTMLSelectElement>) => {
    const selectedPreparationDifficulty = e.target.value as PreparationDifficulty;
    handlePreparationDifficultySelection(selectedPreparationDifficulty);
  };

  return (
    <div className="bg-primary w-72 grid grid-cols-1 gap-4 bg-base-300 rounded-lg drop-shadow-xl p-2 content-start items-start">
      <div className="grid grid-cols-2 content-start items-start">
        <div className="text-left text-xl pl-4 mt-2 transition ease-in-out duration-200 hover:animate-none hover:scale-105">
          <div className="tooltip" data-tip="You can select the maximum preparation difficulty for the recipes">
            Difficulty
          </div>
        </div>
        <select
          name="Max Difficulty"
          defaultValue={"default"}
          title="Difficulty"
          className="select drop-shadow-xl font-bold"
          onChange={handlePreparationDifficultyChange}
        >
          <option value="default" disabled>Select</option>
          {Object.values(PreparationDifficulty).map((preparationDifficulty) => (
            <option key={preparationDifficulty} value={preparationDifficulty}>{preparationDifficulty}</option>
          ))}
        </select>
      </div>
    </div>
  );
};
