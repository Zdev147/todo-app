var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var todos = new List<TodoModel>();

app.MapGet("/getAll", () => Results.Ok(todos));

app.MapGet("/get", (string id) =>
{
    var data = todos.FirstOrDefault(todo => todo.Id == id);
    return data != null ? Results.Ok(data) : Results.NotFound("Todo not found");
});

app.MapPost("/add", (TodoModel todo) =>
{
    var newTodo = todo with { Id = Guid.NewGuid().ToString() };
    todos.Add(newTodo);
    return Results.Created($"/add/{newTodo.Id}", newTodo);
});

app.MapPost("/addAll", (List<TodoModel> todosList) =>
{
    todos.AddRange(todosList);
    return Results.Created("/addAll", "Todos Added");
});

app.MapPut("/update", (TodoModel todo) =>
{
    var index = todos.FindIndex(td => td.Id == todo.Id);
    if (index >= 0)
    {
        todos[index] = todo;
        return Results.Ok($"Todo {todo.Id} updated");
    }
    return Results.NotFound("Todo not found");
});

app.MapDelete("/delete", (string id) =>
{
    var removed = todos.RemoveAll(td => td.Id == id);
    return removed > 0 ? Results.Ok("Todo Deleted") : Results.NotFound("Todo not found");
});

app.Run();

public record TodoModel (string Id, string Title, bool IsCompleted);