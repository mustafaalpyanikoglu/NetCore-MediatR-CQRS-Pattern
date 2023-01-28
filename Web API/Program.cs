using MediatR;
using System.Reflection;
using Web_API.Data;
using Web_API.Data.Commands;
using Web_API.Data.Context;
using Web_API.Data.Handlers;
using Web_API.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<MediatorContext>();
builder.Services.AddMediatR(typeof(Program))
                .AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<BaseRepository<Product>>()
                .AddScoped<BaseRepository<Category>>();
builder.Services.AddTransient<CreateCategoryHandler>();
builder.Services.AddTransient<CreateProductHandler>();
builder.Services.AddTransient<GetListCategoryHandler>();
builder.Services.AddTransient<GetListProductHandler>();
builder.Services.AddTransient<GetByIdProductHandler>();
builder.Services.AddTransient<CreateProductCommand>();
builder.Services.AddTransient<CreateCategoryCommand>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
