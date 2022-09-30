using toDoProject.ToDo.Repositories.Interfaces;
using toDoProject.ToDo.Repositories.Models;

namespace toDoProject.toDo.Repositories.Repositories;

public class ToDoItemRepository : IToDoItemRepository {
    static List<ToDoItem> toDoList = new List<ToDoItem>();

    public void AddToList(ToDoItem item)
    {
        toDoList.Add(item);
    }

    public ToDoItem? ChangeInList(Guid? id, string name, bool done)
    {
        for (int i = 0; i < toDoList.Count; i++){
            if (toDoList[i].Id == id){
                string toDoName = toDoList[i].Name;
                toDoList[i].Change(name.Length > 0 ? name : toDoName, done);
                return toDoList[i];
            }
        }
        return null;
    }

    public List<ToDoItem> GetAll()
    {
        return toDoList;
    }

    public List<ToDoItem> GetAllByDate(DateTime? date)
    {
        List<ToDoItem> returnList = new List<ToDoItem>();
        date ??= DateTime.Now;
        foreach (var i in toDoList){
            if (i.DateCreated.Date == date)
                returnList.Add(i);
        }
        return returnList;
    }

    public ToDoItem? GetFromList(Guid? id)
    {
        if (id is null)
            return null;
        foreach (var i in toDoList){
            if (i.Id == id)
                return i;
        }
        return null;
    }

    public ToDoItem? RemoveFromList(Guid? id)
    {
        for (int i = 0; i < toDoList.Count; i++){
            if (toDoList[i].Id == id){
                ToDoItem removedItem = toDoList[i];
                toDoList.RemoveAt(i);
                return removedItem;
            }
        }
        return null;
    }
}