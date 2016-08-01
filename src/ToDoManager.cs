using System;
using ToDoManager.DataAccess;
namespace ToDoManager
{
  class ToDoManager
  {
    private static IToDoRepository repo;

    public static void Main(string[] args)
    {
      Console.WriteLine("Welcome to ToDo Manager");

      repo = new TextToDoRepository();

      GetCount();

      int menuChoice;
      while((menuChoice = GetMenuChoice()) != 0)
      {
        switch(menuChoice)
        {
          case 1:
            Console.WriteLine("Display Items");
            DisplayAllItems();
            break;
          case 2:
            Console.WriteLine("Add new ToDo");
            NewToDo();
            break;
          case 3:
            GetCount();
            break;
        }
      }
    }

    private static void GetCount()
    {
      Console.WriteLine("Loaded {0} ToDo's", repo.Count());
    }

    private static void DisplayMenu()
    {
      Console.WriteLine("Main Menu");
      Console.WriteLine("1. List ToDo's");
      Console.WriteLine("2. Add ToDo");
      Console.WriteLine("3. Get ToDo Count");
      Console.WriteLine("0. Exit");
    }

    private static int GetMenuChoice()
    {
      DisplayMenu();
      int choice = -1;
      string userData = Console.ReadKey().KeyChar.ToString();
      Console.WriteLine();
      if(!int.TryParse(userData, out choice))
      {
        Console.WriteLine("Invalid Menu Option");
      }
      return choice;
    }

    private static void DisplayAllItems()
    {
      var items = repo.GetAllToDos();
      foreach(var item in items)
      {
        Console.WriteLine("{0} - {1} - {2}", item.Id, " ", item.Name);
      }
    }

    private static void NewToDo()
    {
      Console.WriteLine("Name");
      string name = Console.ReadLine();
      repo.NewToDo(name);
    }
  }
}
