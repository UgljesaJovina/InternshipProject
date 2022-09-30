using toDoProject.ToDo.Services.DTOs;

namespace toDoProject.ToDo.Services.Interfaces;


public interface IToDoItemService
{
    List<ToDoItemDTORes> ALLTODOS();
    List<ToDoItemDTORes> GetToDos(DateTime? date);
    ToDoItemDTORes? GetToDo(Guid? id);
    ToDoItemDTORes CreateToDo(ToDoItemDTOCreation toDoItem);
    ToDoItemDTORes? ChangeToDo(Guid? id, ToDoItemDTOReq toDoItem);
    ToDoItemDTORes? DeleteToDo(Guid? id);
}
