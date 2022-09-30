using toDoProject.ToDo.Repositories.Models;

namespace toDoProject.ToDo.Repositories.Interfaces;

public interface IToDoItemRepository {
    void AddToList(ToDoItem item);
    ToDoItem? RemoveFromList(Guid? id);
    ToDoItem? ChangeInList(Guid? id, string itemName, bool done);
    ToDoItem? GetFromList(Guid? id);
    List<ToDoItem> GetAll();
    List<ToDoItem> GetAllByDate(DateTime? date);
}