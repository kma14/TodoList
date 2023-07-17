using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Application.Contracts;
using TodoList.Domain.Common;
using TodoList.Domain.Entities;

namespace TodoList.Persistence.Repositories.StaticRepository
{
    internal class BaseRepository<T> : IAsyncRepository<T> where T : AuditableEntity
    {
        public Task<T> AddAsync(T entity)
        {
            MockDb<T>.ItemList.Add(entity);
            return  Task.FromResult(entity);
        }

        public Task DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T?> GetByIdAsync(Guid id)
        {
            return Task.FromResult(MockDb<T>.FindItem(c => c.Id == id));
        }

        public Task<List<T>> ListAllAsync()
        {
            return Task.FromResult(MockDb<T>.ItemList);
        }

        public Task UpdateAsync(T entity)
        {
            var todoItem = MockDb<T>.FindItem(c => c.Id == entity.Id);
            todoItem = entity;

            return Task.CompletedTask;
        }
    }
}
