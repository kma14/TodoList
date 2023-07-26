import { render, fireEvent, screen, waitFor } from '@testing-library/react';
import userEvent from '@testing-library/user-event';
import TodoItem from './';

const item = {
  id: 1,
  description: "Test item",
  isCompleted: false,
};

test('renders TodoItem without crashing', () => {
  <table>
    <tbody>
      render(<TodoItem item={item} />);
    </tbody>
  </table>
});

test('renders TodoItem with correct id and description', () => {
  const item = {
    id: '1',
    description: 'Test item',
    isCompleted: false
  };

  render(
    <table>
      <tbody>
        <TodoItem item={item} />
      </tbody>
    </table>
  );

  expect(screen.getByText(item.id)).toBeInTheDocument();
  expect(screen.getByText(item.description)).toBeInTheDocument();
});