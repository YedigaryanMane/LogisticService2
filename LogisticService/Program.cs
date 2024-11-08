using LogisticService;
using LogisticService.Models;
using LogisticService.Repository;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRepository<CarType, CarTypeRequest>, CarTypeRepository>();
builder.Services.AddScoped<IRepository<Crashed, CrashedRequest>, CrashedRepository>();
builder.Services.AddScoped<IRepository<Containers, ContainerRequest>, ContainerRepository>();
builder.Services.AddScoped<IRepository<Direction, DirectionRequest>, DirectionRepository>();
builder.Services.AddScoped<IRepository<User, UserRequest>, UserRepository>();
builder.Services.TryAddTransient<DataContext>();
//builder.Services.AddScoped<

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
