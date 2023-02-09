import React from 'react'
import { Fragment } from 'react';
import { Outlet, Link } from 'react-router-dom';
import Footer from '../footer/Footer'
import logo from '@/assets/logo.png';
import { useEffect } from 'react'
import { themeChange } from 'theme-change'

const styles = {
  logo: {
    height: 120,
    display: "flex",
    alignItems: 'center',
  },
} as const;

const Navigation = () => {
  useEffect(() => {
    themeChange(false)
  }, [])
  return (
    <Fragment>
    <div className="navbar bg-base-100">
      <div className="navbar-start">
        <div className="dropdown">
          <label tabIndex={0} className="btn btn-ghost btn-circle">
            <svg xmlns="http://www.w3.org/2000/svg" className="h-5 w-5" fill="none" viewBox="0 0 24 24" stroke="currentColor"><path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M4 6h16M4 12h16M4 18h7" /></svg>
          </label>
          <ul tabIndex={0} className="menu menu-compact dropdown-content mt-3 p-2 shadow bg-base-100 rounded-box w-52">
            <li><Link to="/">Recipes</Link></li>
            <li><Link to="/users">Users</Link></li>
            <li><a>About</a></li>
          </ul>
        </div>
      </div>
      <div className="navbar-center">
        <img src={ logo } style={styles.logo}/>
        <a className="btn btn-ghost normal-case text-xl">What can I cook?</a>
      </div>
      <div className="navbar navbar-end">
        <div className='px-8'>
          <span className='px-8'>Themes</span>
          <select className='select rounded-box font-bold' data-choose-theme>
            <option value="fantasy">Fantasy</option>
            <option value="coffee">Coffee</option>
            <option value="luxury">Luxury</option>
            <option value="garden">Garden</option>
          </select>
        </div>
      <div className="dropdown dropdown-end pr-4">
          <label tabIndex={0} className="btn btn-ghost btn-circle">
            Options
          </label>
          <ul tabIndex={0} className="menu menu-compact dropdown-content mt-3 p-2 shadow bg-base-100 rounded-box w-52">
            <li><a>Placeholder 1</a></li>
            <li><a>placeholder 2</a></li>
            <li><a>Placeholder 3</a></li>
          </ul>
        </div>
      </div>
    </div>
    <Outlet />
    <Footer /> 
    </Fragment>
    
  );
};

export default Navigation;