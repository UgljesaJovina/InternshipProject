using toDoProject.ToDo.Repositories.Models;
using toDoProject.ToDo.Services.Interfaces;
using toDoProject.ToDo.Services.DTOs;
using toDoProject.ToDo.Repositories.Interfaces;


namespace toDoProject.ToDo.Services.Services;


public class ToDoItemService : IToDoItemService {
    readonly IToDoItemRepository itemRepository;

    public ToDoItemService (IToDoItemRepository _itemRepository){
        itemRepository = _itemRepository;
    }

    public List<ToDoItemDTORes> ALLTODOS() => itemRepository.GetAll().Select(i => ToDoItemDTORes.GetResponse(i)).ToList();

    public List<ToDoItemDTORes> GetToDos(DateTime? date){
        List<ToDoItemDTORes> responseList = new List<ToDoItemDTORes>();
        date ??= DateTime.Today;
        foreach (var i in itemRepository.GetAllByDate(date)){
            if (i.DateCreated.Date == date)
                responseList.Add(ToDoItemDTORes.GetResponse(i));
        }
        return responseList;
    }

    public ToDoItemDTORes? GetToDo(Guid? id){
        if (id is null)
            return null;
        ToDoItem? toDo = itemRepository.GetFromList(id);
        if (toDo is null)
            return null;
        else
            return ToDoItemDTORes.GetResponse(toDo);
    }

    public ToDoItemDTORes CreateToDo(ToDoItemDTOCreation toDoItem){
        Dictionary<string, string>? errors = null;
        if (string.IsNullOrEmpty(toDoItem.Name) || toDoItem.Done is null || toDoItem.DateCreated is null){
            errors = new Dictionary<string, string>();
            if (toDoItem.Name is null)
                errors.Add("name", "Name was not provided");
            else if (toDoItem.Name.Length <= 0)
                errors.Add("name", "Name must not be empty");
            if (toDoItem.Done is null)
                errors.Add("done", "The checked state of the object was not provided");
            if (toDoItem.DateCreated is null)
                errors.Add("dateCreated", "Date was invalid or not provided");
        }
        ToDoItem newToDo;
        if (errors is null){
            newToDo = new ToDoItem(toDoItem.Name!, toDoItem.DateCreated ?? DateTime.Now, false);
            itemRepository.AddToList(newToDo);
            return ToDoItemDTORes.GetResponse(newToDo);
        }
        return new ToDoItemDTORes(){
            RequestErrors = errors
        };
    }

    public ToDoItemDTORes? ChangeToDo(Guid? id, ToDoItemDTOReq toDoItem){
        if (id is null || string.IsNullOrEmpty(toDoItem.Name) || toDoItem.Done is null)
            return null;
        ToDoItem? toDo = itemRepository.ChangeInList(id, toDoItem.Name, toDoItem.Done ?? false);
        if (toDo is null)
            return null;
        return ToDoItemDTORes.GetResponse(toDo);
    }

    public ToDoItemDTORes? DeleteToDo(Guid? id){
        if (id is null)
            return null;
        ToDoItem? toDo = itemRepository.RemoveFromList(id);
        if (toDo is null)
            return null;
        return ToDoItemDTORes.GetResponse(toDo);
    }

}