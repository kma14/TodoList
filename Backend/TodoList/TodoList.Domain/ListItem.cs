using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Domain
{
    internal class ListItem
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
