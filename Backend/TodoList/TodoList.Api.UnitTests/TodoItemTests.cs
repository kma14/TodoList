using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TodoList.Application;
using TodoList.Application.Contracts.Persistence;
using TodoList.Application.Repositories;
using TodoList.Domain.Entities;
using Xunit;

namespace TodoList.Api.UnitTests
{
    public class TodoItemTests
    {
        private Mock<ITodoItemPersist> _todoItemPersistMock;
        private readonly TodoItemRepository _repository;

        public TodoItemTests()
        {
            _todoItemPersistMock = new Mock<ITodoItemPersist>();
            _repository = new TodoItemRepository(_todoItemPersistMock.Object);
        }

        [Fact]
        public async Task AddAsync_ItemWithSameDescription_ThrowsException()
        {
            // Arrange
            var todoItem = new TodoItem("Test");
            _todoItemPersistMock.Setup(m => m.TodoItemDescriptionExists("Test")).Returns(true);

            // Act & Assert
            await Assert.ThrowsAsync<ItemAlreadyExistException>(() => _repository.AddAsync(todoItem));
        }

        [Fact]
        public async void GetAll_ReturnsCorrectNumber()
        {
            //Arrange
            TodoItem item1 = new TodoItem("Shopping");
            TodoItem item2 = new TodoItem("Swimming");
            TodoItem item3 = new TodoItem("Interview");
            _todoItemPersistMock.Setup(c => c.ListAllAsync()).Returns(Task.FromResult(new List<TodoItem> { item1, item2, item3 }));

            //Act
            List<TodoItem> contacts = await _repository.ListAllAsync();

            //Assert
            Assert.Equal(3, contacts.Count);
        }

        [Fact]
        public async void GetById_ItemWithSameProperties()
        {
            //Arrange
            TodoItem item1 = new TodoItem("Shopping");
            item1.Id = new Guid("412f32dd-ad5b-41f1-8ef5-1721dd95c966");
            _todoItemPersistMock.Setup(c => c.GetByIdAsync(new Guid("412f32dd-ad5b-41f1-8ef5-1721dd95c966"))).Returns(Task.FromResult(item1));

            //Act
            TodoItem todoItem = await _repository.GetByIdAsync(new Guid("412f32dd-ad5b-41f1-8ef5-1721dd95c966"));

            //Assert
            Assert.NotNull(todoItem);
            Assert.Equal("Shopping", todoItem?.Description);
            Assert.Equal(false, todoItem?.IsCompleted);
        }
    }
}
