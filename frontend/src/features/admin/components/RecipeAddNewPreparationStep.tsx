import { PreparationStep } from "@/features/recipes";
import { useState } from "react";

type props = {
    handlePreparationStepsToPost: (preparationStepsWithoutIds: PreparationStep[]) => void;
}

export const RecipeAddNewPreparationStep: React.FC<props> = ({
    handlePreparationStepsToPost
}) => {
    const [preparationStepDescription, setPreparationStepDescription] = useState<string>("");
    const [preparationStepCount, setPreparationStepCount] = useState<number>(0);
    const [preparationStepList, setPreparationStepList] = useState<PreparationStep[]>([]);

    const handleAddPreparationStep = () => {
        const newPreparationStep = { description: preparationStepDescription, step: preparationStepCount };
        setPreparationStepList([...preparationStepList, newPreparationStep]);
        setPreparationStepDescription("");
        setPreparationStepCount(0);
        handlePreparationStepsToPost([...preparationStepList, newPreparationStep]);
    };

    return (
        <div className="form-control">
            {preparationStepList.length > 0 ? (
                <div className="p-4"><span><b>Added steps:</b></span>
                    <ul>
                        {preparationStepList.map((preparationStep, index) => (
                            <li key={index}
                                className="pl-2 cursor-pointer"
                            >
                                {preparationStep.step}. {preparationStep.description}
                            </li>
                        ))}
                    </ul>
                </div>) : ("")
            }

            <label htmlFor="step">
                <span className="mb-2 font-semibold">Step number<span className="text-error px-0 ml-2">*</span></span>
            </label>
            <input
                type="number"
                min="0"
                className="input input-bordered mb-6"
                placeholder="Add preparation step"
                //value={preparationStepCount}
                onChange={(event) => setPreparationStepCount(parseInt(event.target.value))}
                required />
            <label htmlFor="step-description">
                <span className="mb-2 font-semibold">Step description<span className="text-error px-0 ml-2">*</span></span>
            </label>
            <textarea
                id="step-description"
                className="textarea textarea-bordered"
                placeholder="Step description"
                onChange={(event) => setPreparationStepDescription(event.target.value)}
                //value={preparationStepDescription}
                required>
            </textarea>
            <div className="float-left">
                <button
                    title="Add ingredient to list"
                    className="btn btn-square btn-success mr-2 mt-2"
                    onClick={handleAddPreparationStep}
                >
                    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="#000000" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round"><line x1="12" y1="5" x2="12" y2="19"></line><line x1="5" y1="12" x2="19" y2="12"></line></svg>
                </button>
            </div>
        </div>
    )
}
