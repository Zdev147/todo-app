using Microsoft.EntityFrameworkCore;
using TodoApp.Data;
using TodoApp.Models;

namespace TodoApp.Services;

public class TodoService(TodoDbContext dbContext) : ITodoService
{
    public async Task<List<TodoModel>> GetAll()
    {
        return await dbContext.Todos.ToListAsync();
    }

    public async Task<TodoModel?> GetById(String id)
    {
        return await dbContext.Todos.FindAsync(id);
    }

    public async Task<TodoModel> Create(TodoModel todo)
    {
        dbContext.Todos.Add(todo);
        await dbContext.SaveChangesAsync();
        return todo;
    }

    public async Task<bool> Update(TodoModel newTodo)
    {
        var todo = await dbContext.Todos.FindAsync(newTodo.Id);
        if (todo == null)
            return false;

        dbContext.Todos.Remove(todo);
        dbContext.Todos.Add(newTodo);
        await dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Delete(String id)
    {
        var todo = await dbContext.Todos.FindAsync(id);
        if (todo == null)
            return false;

        dbContext.Todos.Remove(todo);
        await dbContext.SaveChangesAsync();
        return true;
    }
}