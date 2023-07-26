import { render, fireEvent, screen, waitFor } from '@testing-library/react';
import userEvent from '@testing-library/user-event';
import AddItemForm from './';

// Mock axios.post method
jest.mock('axios');

test('renders AddItemForm without crashing', () => {
    render(<AddItemForm handleAdd={() => { }} />);
});

test('shows validation error when trying to add empty item', async () => {
    render(<AddItemForm handleAdd={() => { }} />);
    const input = screen.getByPlaceholderText('Enter description...');
    await userEvent.type(input, '{backspace}');
    userEvent.click(screen.getByRole('button', { name: /Add Item/i }));

    await waitFor(() => expect(screen.getByTestId('errorMessage')).toHaveTextContent('Description field cannot be empty.'));
});

test('clears input and error message on clear', async () => {
    render(<AddItemForm handleAdd={() => { }} />);
    const input = screen.getByPlaceholderText('Enter description...');

    await userEvent.type(input, '111');
    userEvent.click(screen.getByTestId('clear-button'));

    await waitFor(() => expect(input.value).toBe(''));
    expect(screen.queryByRole('alert')).not.toBeInTheDocument();
});

