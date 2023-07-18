import './App.css'
import React, { useState, useEffect } from 'react'
import axios  from 'axios'

import TodoItemList from './Components/TodoItemList'
import Requirement from './Components/Requirement'
import AddItemForm from './Components/AddItemForm'

const App = () => {
  const [items, setItems] = useState([])

  useEffect(() => {
    getItems();
  }, [])

  async function getItems() {
    try {
      const resp = await axios.get(process.env.REACT_APP_API_URL);
      setItems(resp.data);
    } catch (error) {
      console.error(error)
    }
  }

  async function handleAdd(todoItem) {
    await setItems(prevState => [...prevState,todoItem])
    console.log('App',items)
  }

  return (
      <div className="App">
        <div>
          <Requirement/>
        </div>
        <div>
          <AddItemForm handleAdd={handleAdd} />
        </div>
        <div>
          <TodoItemList items={items} getItems={getItems} />
        </div>
      </div>
  )
}

export default App
