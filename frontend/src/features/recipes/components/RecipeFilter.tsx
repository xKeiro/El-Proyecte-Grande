import { useState } from 'react'

export const RecipeFilter = () => {
  const [count, setCount] = useState(0)

  return (
    <div className="sm:container sm:mx-auto sm:px-10 mt-10 grid justify-items-center gap-y-2">
      <h1 className='text-2xl'>
        What can I make?
      </h1>
      <div tabIndex={0} className="collapse border border-secondary bg-base-00 rounded-box mt-5"> 
        <div className="collapse-title text-xl font-medium grid justify-items-center">
          Want to search for recipes? Click me!
        </div>
        <div className="collapse-content"> 
          <label className="label" htmlFor="search-box">
            <span className="label-text">Recipe name filter:</span>
          </label>
          <input tabIndex={0} id="search-box" name="search-box" className="input input-bordered w-full max-w-xs" placeholder='Search for recipe name' type="text" />
        </div>
      </div>
    </div>
  )
}
