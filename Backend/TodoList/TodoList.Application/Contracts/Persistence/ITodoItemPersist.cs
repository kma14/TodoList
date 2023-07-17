using TodoList.Domain.Entities;

namespace TodoList.Application.Contracts.Persistence
{
    public interface ITodoItemPersist : IAsyncRepository<TodoItem>
    {
        public bool TodoItemDescriptionExists(string description);
    }
}
