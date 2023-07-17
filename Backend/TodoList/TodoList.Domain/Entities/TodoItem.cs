using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain.Common;

namespace TodoList.Domain.Entities
{
    public class TodoItem : AuditableEntity
    {
        public string Description { get; set; }
        public bool IsCompleted { get; set; }

        public TodoItem(string description)
        {
            Id = Guid.NewGuid();
            Description = description;
            IsCompleted = false;
            WhenCreated = DateTime.Now;
        }
    }
}
