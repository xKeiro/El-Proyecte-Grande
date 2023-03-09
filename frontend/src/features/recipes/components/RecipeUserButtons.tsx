import { Link } from "react-router-dom";

export const RecipeUserButtons = () => {
    return (
        <div className="user-buttons flex flex-row gap-5 ml-auto">
            <button className="tooltip" data-tip="Like">
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
            <button className="tooltip" data-tip="Dislike">
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
            <button className="tooltip" data-tip="Save">
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