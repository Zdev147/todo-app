using Microsoft.AspNetCore.Mvc;
using TodoApp.Models;
using TodoApp.Services;

namespace TodoApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoController(ITodoService todoService) : ControllerBase
{
    [HttpGet] // api/Todo
    public async Task<IActionResult> GetAll()
    {
        var todos = await todoService.GetAll();
        return Ok(todos);
    }

    [HttpGet("{id}")] // api/Todo/5
    public async Task<IActionResult> GetAll(String id)
    {
        var todo = await todoService.GetById(id);
        return Ok(todo);
    }

    [HttpPost] // api/Todo
    public async Task<IActionResult> Add(TodoModel todoModel)
    {
        var todo = await todoService.Create(todoModel);
        return Ok(todo);
    }

    [HttpPut("id")] // api/Todo/5
    public async Task<IActionResult> Update(TodoModel todoModel)
    {
        var flag = await todoService.Update(todoModel);
        return Ok(flag);
    }

    [HttpDelete("{id}")] // api/Todo/5
    public async Task<IActionResult> Delete(String id)
    {
        var flag = await todoService.Delete(id);
        return Ok(flag);
    }
}