import React, { Fragment, useEffect } from 'react';
import { Link } from 'react-router-dom';
import logo from '@/assets/logo.png';
import { themeChange } from 'theme-change';
import { OptionLink } from "@/features/auth/components/OptionLink";
import { MainPage } from '../../features/recipes/routes/MainPage';

const themes = [
  'light',
  'dark',
  'cupcake',
  'bumblebee',
  'emerald',
  'corporate',
  'synthwave',
  'retro',
  'cyberpunk',
  'valentine',
  'halloween',
  'garden',
  'forest',
  'aqua',
  'lofi',
  'pastel',
  'fantasy',
  'wireframe',
  'black',
  'luxury',
  'dracula',
  'cmyk',
  'autumn',
  'business',
  'acid',
  'lemonade',
  'night',
  'coffee',
  'winter',
];

const styles = {
  logo: {
    height: 50,
    display: 'flex',
    alignItems: 'center',
  },
} as const;

export const NavBar = ({ username, isAdmin, setUsername, setIsAdmin } : {
  username : string | null,
  isAdmin : boolean,
  setUsername : React.Dispatch<React.SetStateAction<string | null>>,
  setIsAdmin : React.Dispatch<React.SetStateAction<boolean>> }) => {

  useEffect(() => {
    themeChange(false);
  }, []);
  return (
    <Fragment>
      <div className="navbar bg-neutral text-neutral-content mb-5">
        <div className="navbar-start w-1/3">
          { isAdmin &&
          <div className="dropdown">
            <label tabIndex={0} className="btn btn-ghost btn-circle">
              <svg
                xmlns="http://www.w3.org/2000/svg"
                className="h-7 w-7"
                fill="none"
                viewBox="0 0 24 24"
                stroke="currentColor"
              >
                <path
                  strokeLinecap="round"
                  strokeLinejoin="round"
                  strokeWidth="2"
                  d="M4 6h16M4 12h16M4 18h7"
                />
              </svg>
            </label>
            <ul
              tabIndex={0}
              className="menu menu-compact dropdown-content mt-3 p-2 shadow-xl rounded-box w-52 bg-neutral">
              <li>
                <Link to="/admin/recipe-properties" className="text-xl">
                  Recipe Properties
                </Link>
              </li>
              <li>
                <Link to="/admin/recipes" className="text-xl">
                  Recipes
                </Link>
              </li>
              <li>
                <Link to="/admin/users" className="text-xl">
                  Users
                </Link>
              </li>
            </ul>
          </div>
          }
          {
            <div className="md:max-2xl:ml-4">{username == null ? "Not logged in" : "Hello " + username}</div>
          }
        </div>
        <div className="navbar-center min-[320px]:max-[425px]:invisible min-[425px]:justify-center w-1/3">
          <Link to="/">
            <img src={logo} alt="What can I cook logo" style={styles.logo} />
          </Link>
          <Link to="/" className="btn btn-ghost normal-case invisible w-0 lg:w-60 lg:visible lg:text-xl">
            What can I cook?
          </Link>
        </div>
        <div className="navbar navbar-end w-1/3">
          <div className="md:max-2xl:px-8">
            <span className="mr-2 invisible w-0 lg:w-12 lg:visible">Theme:</span>
            <select
              className="select rounded-box font-bold items-center justify-center bg-neutral text-neutral-content"
              data-choose-theme
            >
              {themes.map((theme) => (
                <option key={theme} value={theme}>
                  {theme.charAt(0).toUpperCase() + theme.slice(1)}
                </option>
              ))}
            </select>
          </div>
          <div className="dropdown dropdown-end md:max-2xl:pr-4">
            <label tabIndex={0} className="btn btn-ghost btn-circle">
            <svg className="h-4 w-4 md:h-6 w-6" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round"><circle cx="12" cy="12" r="3"></circle><path d="M19.4 15a1.65 1.65 0 0 0 .33 1.82l.06.06a2 2 0 0 1 0 2.83 2 2 0 0 1-2.83 0l-.06-.06a1.65 1.65 0 0 0-1.82-.33 1.65 1.65 0 0 0-1 1.51V21a2 2 0 0 1-2 2 2 2 0 0 1-2-2v-.09A1.65 1.65 0 0 0 9 19.4a1.65 1.65 0 0 0-1.82.33l-.06.06a2 2 0 0 1-2.83 0 2 2 0 0 1 0-2.83l.06-.06a1.65 1.65 0 0 0 .33-1.82 1.65 1.65 0 0 0-1.51-1H3a2 2 0 0 1-2-2 2 2 0 0 1 2-2h.09A1.65 1.65 0 0 0 4.6 9a1.65 1.65 0 0 0-.33-1.82l-.06-.06a2 2 0 0 1 0-2.83 2 2 0 0 1 2.83 0l.06.06a1.65 1.65 0 0 0 1.82.33H9a1.65 1.65 0 0 0 1-1.51V3a2 2 0 0 1 2-2 2 2 0 0 1 2 2v.09a1.65 1.65 0 0 0 1 1.51 1.65 1.65 0 0 0 1.82-.33l.06-.06a2 2 0 0 1 2.83 0 2 2 0 0 1 0 2.83l-.06.06a1.65 1.65 0 0 0-.33 1.82V9a1.65 1.65 0 0 0 1.51 1H21a2 2 0 0 1 2 2 2 2 0 0 1-2 2h-.09a1.65 1.65 0 0 0-1.51 1z"></path></svg>
            </label>
            <ul
              tabIndex={0}
              className="menu menu-compact dropdown-content mt-3 p-2 shadow bg-neutral rounded-box w-52">
              {
                username != null &&
                <li className="sm:hidden">
                  <OptionLink text={"Main Page"} to={"/"} isLogout={false} />
                </li>
              }
              {
                username == null &&
                <li>
                  <OptionLink text={"Login"} to={"/login"} isLogout={false} />
                </li>
              }
              {
                username == null &&
                <li>
                  <OptionLink text={"Register"} to={"/register"} isLogout={false} />
                </li>
              }
              {
                  username != null &&
                  <li>
                    <OptionLink text={"Profile"} to={"/profile"} isLogout={false} setUsername={setUsername} setIsAdmin={setIsAdmin} />
                  </li>
              }
              {
                username != null &&
                <li>
                  <OptionLink text={"Logout"} to={"/"} isLogout={true} setUsername={setUsername} setIsAdmin={setIsAdmin} />
                </li>
              }
            </ul>
          </div>
        </div>
      </div>
    </Fragment>
  );
};
