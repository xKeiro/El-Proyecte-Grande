import { Link } from "react-router-dom";
import { TUserRecipeStatus, UserRecipeStatus } from "@/features/users";
import { UsersApi } from "@/features/users/api/UsersApi";
import { useEffect, useState } from 'react';

type props = {
    recipeId: number;
};

export const RecipeUserButtons: React.FC<props> = ({ recipeId }) => {
    const [recipeStatus, setRecipeStatus] = useState<UserRecipeStatus | null>(null);
    const getUserRecipeStatus = async () => {
        const userRecipeStatus = await UsersApi.getUserRecipeStatus(recipeId);
        setRecipeStatus(userRecipeStatus.name);
    };
    const handleStatusAddition = async (event: React.MouseEvent<HTMLButtonElement, MouseEvent>, status: UserRecipeStatus) => {
        event.preventDefault();
        UsersApi.addUserRecipeStatus(recipeId, status);
        setRecipeStatus(status);
    };
    const handleStatusDeletion = async (event: React.MouseEvent<HTMLButtonElement, MouseEvent>) => {
        event.preventDefault();
        UsersApi.deleteUserRecipeStatus(recipeId);
        setRecipeStatus(null);
    };
    useEffect(() => {
        getUserRecipeStatus();
    }, []);
    if (!recipeStatus) {
        return (
            <div className="user-buttons flex flex-row gap-5 ml-auto">
                <button className="tooltip" data-tipe="Like" onClick={(event) => { handleStatusAddition(event, UserRecipeStatus.Liked) }}>
                    <Link to="#">
                        <svg xmlns="http://www.w3.org/2000/svg"
                            className="h-7 w-7"
                            viewBox="0 0 24 24"
                            fill="none"
                            stroke="currentColor"
                            strokeWidth="2"
                            strokeLinecap="round"
                            strokeLinejoin="round">
                            <path d="M20.84 4.61a5.5 5.5 0 0 0-7.78 0L12 5.67l-1.06-1.06a5.5 5.5 0 0 0-7.78 7.78l1.06 1.06L12 21.23l7.78-7.78 1.06-1.06a5.5 5.5 0 0 0 0-7.78z"></path>
                        </svg>
                    </Link>
                </button>
                <button className="tooltip" data-tipe="Dislike" onClick={(event) => { handleStatusAddition(event, UserRecipeStatus.Disliked) }}>
                    <Link to="#">
                        <svg xmlns="http://www.w3.org/2000/svg"
                            className="h-7 w-7"
                            viewBox="0 0 24 24"
                            fill="none"
                            stroke="currentColor"
                            strokeWidth="2"
                            strokeLinecap="round"
                            strokeLinejoin="round">
                            <circle cx="12" cy="12" r="10"></circle>
                            <line x1="4.93" y1="4.93" x2="19.07" y2="19.07"></line>
                        </svg>
                    </Link>
                </button>
                <button className="tooltip" data-tipe="Save" onClick={(event) => { handleStatusAddition(event, UserRecipeStatus.Saved) }}>
                    <Link to="#">
                        <svg xmlns="http://www.w3.org/2000/svg"
                            className="h-7 w-7"
                            viewBox="0 0 24 24"
                            fill="none"
                            stroke="currentColor"
                            strokeWidth="2"
                            strokeLinecap="round"
                            strokeLinejoin="round">
                            <path d="M19 21l-7-5-7 5V5a2 2 0 0 1 2-2h10a2 2 0 0 1 2 2z"></path>
                        </svg>
                    </Link>
                </button>
            </div>
        );
    }
    else if (recipeStatus === UserRecipeStatus.Liked) {
        return (
            <div className="user-buttons flex flex-row gap-5 ml-auto">
                <button className="tooltip hover:bg-error hover:text-error-content cursor-pointer" data-tipe="Like" onClick={(event) => { handleStatusDeletion(event) }}>
                    <Link to="#">
                        <svg xmlns="http://www.w3.org/2000/svg"
                            className="h-7 w-7"
                            viewBox="0 0 24 24"
                            fill="none"
                            stroke="currentColor"
                            strokeWidth="2"
                            strokeLinecap="round"
                            strokeLinejoin="round">
                            <path d="M20.84 4.61a5.5 5.5 0 0 0-7.78 0L12 5.67l-1.06-1.06a5.5 5.5 0 0 0-7.78 7.78l1.06 1.06L12 21.23l7.78-7.78 1.06-1.06a5.5 5.5 0 0 0 0-7.78z"></path>
                        </svg>
                    </Link>
                </button>
            </div>
        )
    }
    else if (recipeStatus === UserRecipeStatus.Disliked) {
        return (
            <div className="user-buttons flex flex-row gap-5 ml-auto">
                <button className="tooltip hover:bg-error hover:text-error-content cursor-pointer" data-tipe="Dislike" onClick={(event) => { handleStatusDeletion(event) }}>
                    <Link to="#">
                        <svg xmlns="http://www.w3.org/2000/svg"
                            className="h-7 w-7"
                            viewBox="0 0 24 24"
                            fill="none"
                            stroke="currentColor"
                            strokeWidth="2"
                            strokeLinecap="round"
                            strokeLinejoin="round">
                            <circle cx="12" cy="12" r="10"></circle>
                            <line x1="4.93" y1="4.93" x2="19.07" y2="19.07"></line>
                        </svg>
                    </Link>
                </button>
            </div>
        )
    }
    else {
        return (
            <div className="user-buttons flex flex-row gap-5 ml-auto">
                <button className="tooltip hover:bg-error hover:text-error-content cursor-pointer" data-tipe="Save" onClick={(event) => { handleStatusDeletion(event) }}>
                    <Link to="#">
                        <svg xmlns="http://www.w3.org/2000/svg"
                            className="h-7 w-7"
                            viewBox="0 0 24 24"
                            fill="none"
                            stroke="currentColor"
                            strokeWidth="2"
                            strokeLinecap="round"
                            strokeLinejoin="round">
                            <path d="M19 21l-7-5-7 5V5a2 2 0 0 1 2-2h10a2 2 0 0 1 2 2z"></path>
                        </svg>
                    </Link>
                </button>
            </div>
        )
    }
}