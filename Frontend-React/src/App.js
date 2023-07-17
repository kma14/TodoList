import './App.css'
import React, { useState, useEffect } from 'react'

import {TodoItemList} from './Components/TodoItemList'
import Requirement from './Components/Requirement'
import AddItemForm from './Components/AddItemForm'

const axios = require('axios')

const App = () => {
  const [description, setDescription] = useState('')
  const [items, setItems] = useState([])

  useEffect(() => {
    // todo
  }, [])

  async function getItems() {
    try {
      alert('todo')
    } catch (error) {
      console.error(error)
    }
  }

  async function handleAdd() {
    try {
      alert('todo')
    } catch (error) {
      console.error(error)
    }
  }

  function handleClear() {
    setDescription('')
  }

  async function handleMarkAsComplete(item) {
    try {
      alert('todo')
    } catch (error) {
      console.error(error)
    }
  }

  return (
      <div className="App">
        <div>
          <Requirement/>
        </div>
        <div>
          <AddItemForm handleAdd={handleAdd} handleClear={handleClear} description={description} setDescription={setDescription} />
        </div>
        <div>
          <TodoItemList items={items} getItems={getItems} />
        </div>
      </div>
  )
}

export default App
