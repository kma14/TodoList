using Microsoft.Extensions.DependencyInjection;
using TodoList.Application.Contracts.API;
using TodoList.Application.Repositories;

namespace TodoList.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ITodoItem, TodoItemRepository>();
            return services;
        }
    }
}
