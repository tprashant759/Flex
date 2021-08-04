using System;
namespace Shared
{
    public class ToDoItem
    {
        public Guid id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Done { get; set; }
    }
}
