using TodoList.Domain.Entities;

namespace TodoList.Application.Contracts.API
{
    public interface ITodoItem:IAsyncRepository<TodoItem>
    {
        public bool TodoItemDescriptionExists(string description);
    }
}
