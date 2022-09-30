using Microsoft.AspNetCore.Mvc;
using toDoProject.ToDo.Services.DTOs;
using toDoProject.ToDo.Services.Interfaces;

namespace toDoProject.ToDo.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ToDoItemsController : ControllerBase {
    private readonly IToDoItemService itemService;

    public ToDoItemsController(IToDoItemService itemService)
    {
        this.itemService = itemService;
    }

    [HttpGet("ALLTODOS")]
    public ActionResult<List<ToDoItemDTORes>> GetToDos(){
        return Ok(itemService.ALLTODOS());
    }

    [HttpGet("GetToDos")]
    public ActionResult<List<ToDoItemDTORes>> GetToDos(DateTime? date){
        return Ok(itemService.GetToDos(date));
    }

    [HttpGet("GetToDo/{id}")]
    public ActionResult<ToDoItemDTORes> GetToDo(Guid id){
        ToDoItemDTORes? response = itemService.GetToDo(id);
        if (response is not null)
            return Ok(response);
        else
            return NotFound();
    }

    [HttpPost("MakeToDo")]
    public ActionResult<ToDoItemDTORes> CreateToDo(ToDoItemDTOCreation toDo){
        ToDoItemDTORes? newToDo = itemService.CreateToDo(toDo);
        if (newToDo.RequestErrors is null)
            return Created($"{Url.PageLink()}/{newToDo.Id}", newToDo);
        else
            return BadRequest(newToDo);
        // return CreatedAtAction("GetItem", ToDoItemDTORes.GetResponse(newToDo));
    }

    [HttpPut("ChangeToDo/{id}")]
    public ActionResult<ToDoItemDTORes> ChangeToDo(Guid id, ToDoItemDTOReq toDo){
        ToDoItemDTORes? response = itemService.ChangeToDo(id, toDo);
        if (response is not null)
            return Ok(response);
        else
            return NotFound();
    }

    [HttpDelete("DeleteToDo/{id}")]
    public ActionResult<ToDoItemDTORes> DeleteToDo(Guid id){
        ToDoItemDTORes? response = itemService.DeleteToDo(id);
        if (response is not null)
            return NoContent();
        else
            return NotFound();
    }
}
