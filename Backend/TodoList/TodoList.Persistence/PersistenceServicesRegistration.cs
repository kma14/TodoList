using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Application.Contracts;
using TodoList.Application.Contracts.Persistence;
using TodoList.Persistence.Repositories.StaticRepository;

namespace TodoList.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection AddPersistenceService(this IServiceCollection services)
        {
            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ITodoItemPersist, TodoItemRepository>();
            return services;
        }
    }
}
