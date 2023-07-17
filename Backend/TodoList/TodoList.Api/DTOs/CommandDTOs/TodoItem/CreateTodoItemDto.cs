using System.ComponentModel.DataAnnotations;

namespace TodoList.Api.DTOs.CommandDTOs.TodoItem
{
    public class CreateTodoItemDto
    {
        [Required(ErrorMessage = "Description can not be empty")]
        public string Description { get; set; }
    }
}
