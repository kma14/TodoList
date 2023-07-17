using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Domain.Common
{
    internal class AuditableEntity
    {
        public DateOnly WhenCreated { get; set; }
    }
}
