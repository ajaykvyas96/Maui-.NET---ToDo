using System;
using ToDo.WebAPI.Data;
using Microsoft.EntityFrameworkCore;
using ToDo.WebAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(option =>
    option.UseSqlite(builder.Configuration.GetConnectionString("ToDo")));

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

// app.UseHttpsRedirection();

app.MapGet("api/todo", async (AppDbContext context) =>
{
    var items = await context.ToDos.ToListAsync();
    return Results.Ok(items);
});

app.MapGet("api/todo/{id}", async (AppDbContext context, int id) =>
{
    var toDo = await context.ToDos.FirstOrDefaultAsync(x => x.Id == id);
    return Results.Ok(toDo);
});

app.MapPost("api/todo", async (AppDbContext context, ToDoItem toDo) =>
{
    await context.ToDos.AddAsync(toDo);
    await context.SaveChangesAsync();
    return Results.Created($"api/todo/{toDo.Id}", toDo);
});

app.MapPut("api/todo/{id}", async (AppDbContext context, int id, ToDoItem toDo) =>
{
    var toDoModel = await context.ToDos.FirstOrDefaultAsync(x => x.Id == id);
    if (toDoModel == null)
    {
        return Results.NotFound();
    }
    toDoModel.ToDoName = toDo.ToDoName;
    context.ToDos.Update(toDoModel);
    await context.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("api/todo/{id}", async (AppDbContext context, int id) =>
{
    var toDoModel = await context.ToDos.FirstOrDefaultAsync(x => x.Id == id);
    if (toDoModel == null)
    {
        return Results.NotFound();
    }
    context.ToDos.Remove(toDoModel);
    await context.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();