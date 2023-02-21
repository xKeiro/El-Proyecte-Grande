import { Navigate } from 'react-router-dom';

export const EditRecipe = () => {
    let isAdmin = true;

    if (isAdmin)
        return (
            <div id="recipe-container">

            </div>
        );
    return (<Navigate to="/unauthorized" />);
};
