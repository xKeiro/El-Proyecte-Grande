import {TPreparation} from "@/features/recipes";

export const RecipePreparation = (props : {preparationSteps : TPreparation[]}) => {
    return (
        <div className="card-body recipe-info bg-base-100 rounded-box">
            <ol className="list-decimal marker:font-bold">
                {
                    props.preparationSteps.map((prepStep : TPreparation) => (
                        <li key={prepStep.step} className="ml-4 mb-5"><p className="ml-4">{prepStep.description}</p></li>
                    ))
                }
            </ol>
        </div>
    )
}