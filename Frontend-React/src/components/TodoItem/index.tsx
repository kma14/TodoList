import axios from "axios";
import React, { useState, useEffect, FormEvent } from "react";
import { TodoItemType } from '../../models';

interface TodoItemProps {
    item: TodoItemType;
}
const TodoItem: React.FC<TodoItemProps> = ({ item: propItem }) => {
    const [item, setItem] = useState(propItem);

    useEffect(() => {
        setItem(propItem);
    }, [propItem]);

    const updateItem = async (event: FormEvent) => {
        event.preventDefault();
        const payload = { description: item.description, IsCompleted: true }
        try {
            const resp = await axios.put(`${process.env.REACT_APP_API_URL}/${item.id}`, payload);
            console.log(resp);
            setItem(prevItem => ({ ...prevItem, isCompleted: true }));
        } catch (error) {

        }
    }
    return (
        <>
            <tr style={item.isCompleted ? { textDecoration: 'line-through' } : { fontWeight: 'bold' }}>
                <td>{item.id}</td>
                <td>{item.description}</td>
                <td>
                    <form onSubmit={updateItem}>
                        <button type='submit' disabled={item.isCompleted} className="btn btn-warning btn-sm"  >
                            Mark as completed
                        </button>
                    </form>
                </td>
            </tr>
        </>
    )
}

export default TodoItem;