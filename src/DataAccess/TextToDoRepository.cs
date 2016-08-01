using System;
using System.Collections.Generic;
using System.IO;
using ToDoManager.DataAccess.Models;

namespace ToDoManager.DataAccess
{
  class TextToDoRepository : IToDoRepository
  {
    private readonly string fileName = "todos.txt";
    private readonly string backupFile = "todos.bak";
    private List<ToDo> collection;

    public TextToDoRepository()
    {
      collection = new List<ToDo>();
      LoadFromFile();
    }

    public int Count()
    {
      return collection.Count;
    }

    public List<ToDo> GetAllToDos()
    {
      return collection;
    }

    public void NewToDo(string name)
    {
      var toDo = new ToDo();
      toDo.Id = 0;
      toDo.Name = name;
      toDo.IsCompleted = false;
      collection.Add(toDo);
      SaveToFile();
    }

    private void LoadFromFile()
    {
      if(File.Exists(fileName))
      {
        using(StreamReader sr = File.OpenText(fileName))
        {
          string line = "";
          while((line = sr.ReadLine()) != null)
          {
            string[] parts = line.Split('\t');
            collection.Add(new ToDo(Convert.ToInt32(parts[0]), parts[1], Convert.ToBoolean(parts[2])));
          }
        }
      }
    }

    private void SaveToFile()
    {
      if(File.Exists(fileName))
      {
        if(File.Exists(backupFile))
        {
          File.Delete(backupFile);
          File.Move(fileName, backupFile);
        }
      }

      using(StreamWriter sw = File.CreateText(fileName))
      {
        foreach(var toDo in collection)
        {
          sw.WriteLine(String.Format("{0}\t{1}\t{2}", toDo.Id, toDo.Name, toDo.IsCompleted));
        }
      }
    }
  }
}
