import { Navigate } from 'react-router-dom';

export const EditRecipe = ({ isAdmin } : { isAdmin : boolean }) => {

    if (isAdmin)
        return (
            <div id="recipe-container">

            </div>
        );
    return (<Navigate to="/unauthorized" />);
};
