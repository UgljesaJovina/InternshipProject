using toDoProject.ToDo.Repositories.Models;

namespace toDoProject.ToDo.Services.DTOs;

public class ToDoItemDTORes{
    public Guid Id { get; private set; }
    public string Name { get; set; }
    public DateTime DateCreated { get; set; }
    public bool? Done { get; set; }
    public Dictionary<string, string>? RequestErrors { get; set; }

    public ToDoItemDTORes(){
    }

    public ToDoItemDTORes(Guid _id, string _name, DateTime _dateCreated, bool? _done){
        Id = _id;
        Name = _name;
        DateCreated = _dateCreated;
        Done = _done;
    }

    public static ToDoItemDTORes GetResponse(ToDoItem toDoItem){
        return new ToDoItemDTORes (toDoItem.Id, toDoItem.Name, toDoItem.DateCreated, toDoItem.Done);
    }
}