import {Link} from "react-router-dom";

const Title = () => {
    return (
        <div className="navbar-center hidden lg:flex">
            <button><Link to="/"><img src="/src/assets/react.svg" alt="what-can-i-cook"/></Link></button>
            <ul className="menu menu-horizontal px-1">
              <li><Link className="btn btn-ghost normal-case text-xl" to="/">What can I cook?</Link></li>
            </ul>
        </div>
    )
}

export default Title