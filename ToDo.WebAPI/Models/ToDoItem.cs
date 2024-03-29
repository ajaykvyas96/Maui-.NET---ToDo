using System.ComponentModel.DataAnnotations;

namespace ToDo.WebAPI.Models
{
    public class ToDoItem
    {
        [Key]
        public int Id { get; set; }
        public string? ToDoName { get; set; }
    }
}
