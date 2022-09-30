using toDoProject.ToDo.Services.Interfaces;
using toDoProject.ToDo.Repositories.Interfaces;
using toDoProject.ToDo.Services.Services;
using toDoProject.toDo.Repositories.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region dependecy injections

builder.Services.AddTransient<IToDoItemService, ToDoItemService>();
builder.Services.AddTransient<IToDoItemRepository, ToDoItemRepository>();

#endregion

//ostalo
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(p => p.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
