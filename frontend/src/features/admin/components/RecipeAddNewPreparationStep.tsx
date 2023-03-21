import { RequiredStar } from "@/components/Form/RequiredStar";
import { PreparationStep } from "@/features/recipes";
import { useState } from "react";

type props = {
    handlePreparationStepsToPost: (preparationStepsWithoutIds: PreparationStep[]) => void;
}

export const RecipeAddNewPreparationStep: React.FC<props> = ({
    handlePreparationStepsToPost
}) => {
    const [preparationStepDescription, setPreparationStepDescription] = useState<string>("");
    const [preparationStepCount, setPreparationStepCount] = useState<number>(1);
    const [preparationStepList, setPreparationStepList] = useState<PreparationStep[]>([]);

    const handleAddPreparationStep = () => {
        if(preparationStepCount != 0){
            const existingStep = preparationStepList.find(step => step.step === preparationStepCount);
            if (existingStep) {
              alert(`Step ${preparationStepCount} already exists. Please enter a different step number.`);
              return;
            }      
            const newPreparationStep = { description: preparationStepDescription, step: preparationStepCount };
            setPreparationStepList([...preparationStepList, newPreparationStep]);
            setPreparationStepDescription("");
            setPreparationStepCount(preparationStepCount+1);
            handlePreparationStepsToPost([...preparationStepList, newPreparationStep]);
        }

    };

    const handleDeletePreparationStep = (index: number) => {
        const updatedPreparationStepList = [...preparationStepList];
        updatedPreparationStepList.splice(index, 1);
        setPreparationStepList(updatedPreparationStepList);
        handlePreparationStepsToPost(updatedPreparationStepList);
    };

    return (
        <div className="form-control">
            {preparationStepList.length > 0 ? (
                <div className="p-4 bg-base-200 rounded"><span><b>Added steps:</b></span>
                    <ul className="break-words">
                        {preparationStepList.map((preparationStep, index) => (
                            <li key={index}
                                className="pl-2 cursor-pointer"
                                title="Delete this step"
                                onClick={() => handleDeletePreparationStep(index)}
                            >
                                {preparationStep.step}. {preparationStep.description}
                            </li>
                        ))}
                    </ul>
                </div>) : ("")
            }

            <label htmlFor="step">
                <span className="mb-2 font-semibold">Step number<RequiredStar/></span>
            </label>
            <input
                type="number"
                className="input input-bordered mb-6"
                placeholder="Add preparation step"
                value={preparationStepCount}
                //onChange={(event) => setPreparationStepCount(parseInt(event.target.value))}
                onChange={(event) =>{
                    const value = Number(event.target.value);
                    if(value>0){
                        setPreparationStepCount(value);
                    }
                }}
                required={preparationStepList.length === 0 ? true : false} />
            <label htmlFor="step-description">
                <span className="mb-2 font-semibold">Step description<RequiredStar/></span>
            </label>
            <textarea
                id="step-description"
                className="textarea textarea-bordered"
                placeholder="Step description"
                onChange={(event) => setPreparationStepDescription(event.target.value)}
                value={preparationStepDescription}
                required={preparationStepList.length === 0 ? true : false} >
            </textarea>
            <div className="btn-sm flex justify-center">
                <button
                    title="Add preparation step"
                    className="btn btn-circle btn-sm btn-success mr-2 mt-2"
                    onClick={handleAddPreparationStep}
                >
                    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="#000000" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round"><line x1="12" y1="5" x2="12" y2="19"></line><line x1="5" y1="12" x2="19" y2="12"></line></svg>
                </button>
            </div>
        </div>
    )
}
