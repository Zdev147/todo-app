using TodoApp.Models;

namespace TodoApp.Services;

public interface ITodoService
{
    Task<List<TodoModel>> GetAll();
    Task<TodoModel?> GetById(String id);
    Task<TodoModel> Create(TodoModel model);
    Task<bool> Update(TodoModel model);
    Task<bool> Delete(String id);
}