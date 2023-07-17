using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Application.Contracts.API;
using TodoList.Application.Contracts.Persistence;
using TodoList.Domain.Entities;

namespace TodoList.Application.Repositories
{
    internal class TodoItemRepository : ITodoItem
    {
        private readonly ITodoItemPersist _todoItemPersistRepo;
        public TodoItemRepository(ITodoItemPersist todoItemPersistRepo)
        {
            _todoItemPersistRepo = todoItemPersistRepo;
        }
        public Task<TodoItem> AddAsync(TodoItem entity)
        {
            return _todoItemPersistRepo.AddAsync(entity);
        }

        public Task DeleteAsync(TodoItem entity)
        {
            return _todoItemPersistRepo.DeleteAsync(entity);
        }

        public Task<TodoItem?> GetByIdAsync(Guid id)
        {
            return _todoItemPersistRepo.GetByIdAsync(id);
        }

        public Task<List<TodoItem>> ListAllAsync()
        {
            return _todoItemPersistRepo.ListAllAsync();
        }

        public bool TodoItemDescriptionExists(string description)
        {
            return _todoItemPersistRepo.TodoItemDescriptionExists(description);
        }

        public Task UpdateAsync(TodoItem entity)
        {
           return _todoItemPersistRepo.UpdateAsync(entity);
        }
    }
}
