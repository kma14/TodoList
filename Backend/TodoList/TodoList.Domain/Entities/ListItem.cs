using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain.Common;

namespace TodoList.Domain.Entities
{
    public class ListItem : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }

        public ListItem(string name, string description)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            IsCompleted = false;
        }
    }
}
