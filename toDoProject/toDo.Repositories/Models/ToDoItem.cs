namespace toDoProject.ToDo.Repositories.Models;

public class ToDoItem{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime DateCreated { get; private set; }
    public bool Done { get; set; }

    public ToDoItem(){
    }

    public ToDoItem(Guid _id, string _name, DateTime _dateCreated, bool _done){
        Id = _id;
        Name = _name;
        DateCreated = _dateCreated;
        Done = _done;
    }

    public ToDoItem(string _name, DateTime _dateCreated, bool _done){
        Id = Guid.NewGuid();
        if (_name.Length <= 0)
            throw new ArgumentException(message: "The name provided is not valid", paramName: nameof(Name));
        Name = _name;
        DateCreated = _dateCreated;
        Done = _done;
    }

    public void Change(string _name, bool _done){
        if (_name.Length > 0)
            Name = _name;
        Done = _done;
    }
}
