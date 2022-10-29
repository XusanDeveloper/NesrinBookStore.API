using Microsoft.EntityFrameworkCore;
using NesrinBookStore.API.Models;
using NesrinBookStore.API.Services;
using NesrinBookStore.Data.Contexts;
using NesrinBookStore.Data.Contracts;
using NesrinBookStore.Data.Repositories;
using NesrinBookStore.Services.Interfaces;
using NesrinBookStore.Services.Mappers;
using Repository;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddDbContextPool<NesrinDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BookDb")));
builder.Services.AddScoped<IBookRepository, BookRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
