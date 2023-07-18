import { render, fireEvent, screen, waitFor } from '@testing-library/react';
import userEvent from '@testing-library/user-event';
import TodoItemList from './';

const items = [{
    "description": "sleeping",
    "isCompleted": true,
    "id": "eabd2a0f-39f2-403d-802e-1e46f5f45e02",
    "whenCreated": "2023-07-18T22:14:12.6809031+12:00"
}]

test('renders TodoItemList without crashing', () => {
    render(<TodoItemList items={items} getItems={() => { }} />);
});
