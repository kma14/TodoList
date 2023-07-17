using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain.Common;
using TodoList.Domain.Entities;

namespace TodoList.Persistence.Repositories.StaticRepository
{
    public static class MockDb<T> where T : AuditableEntity
    {
        public static List<T> ItemList { get; } = new List<T>() { };

        public static T? FindItem(Predicate<T> match)
        {
            return ItemList.Find(match);
        }
    }
}
