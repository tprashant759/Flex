using System;
using SQLite;

namespace Shared
{
    public class ToDoItem
    {
        [PrimaryKey]
        public Guid id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; }
    }
}
