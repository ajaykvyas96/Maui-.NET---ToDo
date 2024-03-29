using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.MauiClient.Models;

namespace ToDo.MauiClient.DataServices
{
    public interface IRestDataService
    {
        Task<List<ToDoItem>> GetAllToDosAsync();
        Task AddToDoAsync(ToDoItem toDo);
        Task UpdateToDoAsync(int id, ToDoItem toDo);
        Task DeleteToDoAsync(int id);
    }
}
