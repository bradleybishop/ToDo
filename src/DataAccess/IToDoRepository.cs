using System.Collections.Generic;
using ToDoManager.DataAccess.Models;
namespace ToDoManager.DataAccess
{
  public interface IToDoRepository
  {
    int Count();
    List<ToDo> GetAllToDos();
    void NewToDo(string name);
    void UpdateToDoComplete(int id, bool status);
  }
}
