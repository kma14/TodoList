import './App.css'
import React, { useState, useEffect } from 'react'
import axios  from 'axios'

import TodoItemList from './Components/TodoItemList'
import Requirement from './Components/Requirement'
import AddItemForm from './Components/AddItemForm'
import { TodoItemType }  from './models'

const App:React.FC = () => {
  const [items, setItems] = useState<TodoItemType[]>([])

  useEffect(() => {
    getItems();
  }, [])

  async function getItems() {
    try {
      if(process.env.REACT_APP_API_URL){
        const resp = await axios.get(process.env.REACT_APP_API_URL);
        setItems(resp.data);
      }
    } catch (error) {
      console.error(error)
    }
  }

  async function handleAdd(todoItem:TodoItemType) {
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
