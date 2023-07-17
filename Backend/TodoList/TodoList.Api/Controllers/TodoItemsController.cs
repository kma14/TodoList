using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Api.DTOs.CommandDTOs.TodoItem;
using TodoList.Application.Contracts.API;
using TodoList.Domain.Entities;

namespace TodoList.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class TodoItemsController : ControllerBase
    {
        private readonly ITodoItem _toDoItemRepo;
        private readonly ILogger<TodoItemsController> _logger;

        public TodoItemsController(ITodoItem toDoItemRepo, ILogger<TodoItemsController> logger)
        {
            _toDoItemRepo = toDoItemRepo;
            _logger = logger;
        }


        /// <summary>
        /// Get all TodoItems
        /// </summary>
        /// <returns>List of TodoItems</returns>
        [HttpGet("TodoItems")]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItemss()
        {
            return await _toDoItemRepo.ListAllAsync();
        }

        /// <summary>
        /// Get one TodoItem by its id
        /// </summary>
        /// <param name="id">TodoItem Id</param>
        /// <returns>TodoItem</returns>
        [HttpGet("TodoItems/{id}", Name = "GetTodoItemById")]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItemsById(Guid id)
        {
            var TodoItem = await _toDoItemRepo.GetByIdAsync(id);
            return TodoItem != null ? Ok(TodoItem) : NotFound();
        }

        /// <summary>
        /// Update a TodoItem by its id
        /// </summary>
        /// <param name="id">TodoItem Id</param>
        /// <param name="updatedTodoItem">TodoItem dto</param>
        [HttpPut("TodoItems/{id}")]
        public async Task<ActionResult> CreateTodoItemInGroup(Guid id, UpdateTodoItemDto updatedTodoItem)
        {
            var existingTodoItem = await _toDoItemRepo.GetByIdAsync(id);
            if (existingTodoItem == null)
            {
                return NotFound();
            }

            existingTodoItem.Description = updatedTodoItem.Description;
            existingTodoItem.IsCompleted = updatedTodoItem.IsCompleted;

            await _toDoItemRepo.UpdateAsync(existingTodoItem);

            return NoContent();
        }


        /// <summary>
        /// Create new TodoItem, and put it into one group
        /// </summary>
        /// <param name="TodoItemDto">The create TodoItem dto</param>
        /// <returns>TodoItem</returns>
        [HttpPost("TodoItems")]
        public async Task<ActionResult<TodoItem>> CreateTodoItem(CreateTodoItemDto todoItemDto)
        {
            TodoItem newTodoItem = new TodoItem(todoItemDto.Description);
            await _toDoItemRepo.AddAsync(newTodoItem);

            return CreatedAtRoute("GetTodoItemById", new { Id = newTodoItem.Id }, newTodoItem);
        }


        /// <summary>
        /// Check if if active todoitem with the same description already exist
        /// </summary>
        /// <param name="description">todoitem description</param>
        /// <returns>Boolean</returns>
        private bool TodoItemDescriptionExists(string description)
        {
            return _toDoItemRepo.TodoItemDescriptionExists(description);
        }
    }
}
