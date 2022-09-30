namespace toDoProject.ToDo.Services.DTOs;

public class ToDoItemDTOCreation{
    public string? Name { get; set; }
    public DateTime? DateCreated { get; set; }

    public bool? Done { get; set; }

    public ToDoItemDTOCreation(){
    }
}