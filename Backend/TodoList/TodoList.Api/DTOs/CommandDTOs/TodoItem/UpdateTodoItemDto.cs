using System.ComponentModel.DataAnnotations;

namespace TodoList.Api.DTOs.CommandDTOs.TodoItem
{
    public class UpdateTodoItemDto
    {
        [Required(ErrorMessage = "Description can not be empty")]
        public string Description { get; set; }

        [Required(ErrorMessage = "IsCompleted can not be empty")]
        public bool IsCompleted { get; set; }
    }
}
