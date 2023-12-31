import React from 'react'
import { Button,Table} from 'react-bootstrap'
import TodoItem from '../TodoItem'
import { TodoItemType } from '../../models';

interface TodoItemListProps{
  items: TodoItemType[],
  getItems: () => Promise<void>; 
}

const TodoItemList:React.FC<TodoItemListProps> = ({items, getItems}) => {
    return (
      <>
        <h1>
          Showing {items.length} Item(s){' '}
          <Button variant="primary" className="pull-right" onClick={() => getItems()}>
            Refresh
          </Button>
        </h1>

        <Table striped bordered hover>
          <thead>
            <tr>
              <th>Id</th>
              <th>Description</th>
              <th>Action</th>
            </tr>
          </thead>
          <tbody>
            {items.map(item => (
              <TodoItem key={item.id} item={item}/>
            ))}
          </tbody>
        </Table>
      </>
    )
  }

  export  default TodoItemList;