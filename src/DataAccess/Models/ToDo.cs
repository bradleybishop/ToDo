namespace ToDomanager.DataAccess.Models
{
  public class ToDo
  {
    public int Id {get; internal set;}
    public string Name {get; set;}
    public bool IsCompleted {get; set;}

    public ToDo()
    {
      //Default constructor
    }

    public ToDo(int id, string name, bool completed)
    {
      Id = id;
      Name = name;
      IsCompleted = completed;
    }
  }
}
