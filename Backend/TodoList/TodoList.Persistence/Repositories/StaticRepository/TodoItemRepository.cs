using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Application.Contracts.Persistence;
using TodoList.Domain.Entities;

namespace TodoList.Persistence.Repositories.StaticRepository
{
    internal class TodoItemRepository : BaseRepository<TodoItem>, ITodoItemPersist
    {
        public bool TodoItemDescriptionExists(string description)
        {
            return MockDb<TodoItem>.ItemList.Exists(item => item.Description == description && !item.IsCompleted);
        }
    }
}
