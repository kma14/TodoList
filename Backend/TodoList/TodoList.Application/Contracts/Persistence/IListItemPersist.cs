using TodoList.Domain.Entities;

namespace TodoList.Application.Contracts.Persistence
{
    public interface IListItemPersist : IAsyncRepository<ListItem>
    {
        public void MarkCompleted();
    }
}
