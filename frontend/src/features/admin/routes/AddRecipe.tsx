import { Navigate } from 'react-router-dom';
import { Link } from 'react-router-dom';
import { RecipeAddNew } from '../components/RecipeAddNew';

export const AddRecipe = () => {
    let isAdmin = true;

    if (isAdmin)
        return (
            <RecipeAddNew />
        );
    return (<Navigate to="/unauthorized" />);
};