using TodoList.Domain.Entities;

namespace TodoList.Application.Contracts.API
{
    internal interface IListItem:IAsyncRepository<ListItem>
    {
        public void MarkCompleted();
    }
}
