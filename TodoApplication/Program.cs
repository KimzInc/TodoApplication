using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TodoApplication.Data;
using TodoApplication.Dtos;
using TodoApplication.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextPool<TodoDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("TodoItemConnection")));

builder.Services.AddScoped<ITodoRepo, TodoRepo>();

//register automapper for dependency injection
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//API Endpoints

//Get all items
app.MapGet("api/t1/todos", async(ITodoRepo repo, IMapper mapper) =>
{
    var todos = await repo.GetAllTodoItems();
    return Results.Ok(mapper.Map<IEnumerable<TodoReadDto>>(todos));
});

//Get one Item
app.MapGet("api/t1/todos/{id}", async(ITodoRepo repo, IMapper mapper, int id) =>
{
    var todo = await repo.GetTodoItemById(id);
    if (todo!=null)
    {
        return Results.Ok(mapper.Map<TodoReadDto>(todo));
    }

    return Results.NotFound();
});


//Post

app.MapPost("api/t1/todos", async (ITodoRepo repo, IMapper mapper, TodoCreateDto tcdto) => {
    var todoModel = mapper.Map<Todo>(tcdto);

    await repo.CreateTodoItem(todoModel);

    await repo.SaveChangesAsyc();

    var tdReadDto = mapper.Map<TodoReadDto>(todoModel);

    return Results.Created($"api/t1/todos/{tdReadDto.Id}", tdReadDto);

});

//Put/edit
app.MapPut("api/t1/todos/{id}", async(ITodoRepo repo, IMapper mapper, int id, TodoUpdateDto tdUpdateDto) => {
    var todo = await repo.GetTodoItemById(id);
    if (todo == null)
    {
        return Results.NotFound();
    }

    mapper.Map(tdUpdateDto, todo);

    await repo.SaveChangesAsyc();

    return Results.NoContent();

});

app.MapDelete("api/t1/todos/{id}", async (ITodoRepo repo, IMapper mapper, int id) => {
    var todo = await repo.GetTodoItemById(id);
    if (todo == null)
    {
        return Results.NotFound();
    }

    repo.DeleteTodoItem(todo);

    await repo.SaveChangesAsyc();
    return Results.NoContent();
});


app.Run();

