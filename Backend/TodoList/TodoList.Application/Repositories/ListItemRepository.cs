using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Application.Contracts.API;
using TodoList.Domain.Entities;

namespace TodoList.Application.Repositories
{
    internal class ListItemRepository : IListItem
    {
        public Task<ListItem> AddAsync(ListItem entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(ListItem entity)
        {
            throw new NotImplementedException();
        }

        public Task<ListItem?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ListItem>> ListAllAsync()
        {
            throw new NotImplementedException();
        }

        public void MarkCompleted()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ListItem entity)
        {
            throw new NotImplementedException();
        }
    }
}
