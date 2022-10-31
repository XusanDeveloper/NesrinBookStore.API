using Microsoft.EntityFrameworkCore;
using NesrinBookStore.API.Extensions;
using NesrinBookStore.API.Services;
using NesrinBookStore.Data.Contexts;
using NesrinBookStore.Data.Contracts;
using NesrinBookStore.Data.Repositories;
using NesrinBookStore.Services.Interfaces;
using NLog;
using Repository;

var builder = WebApplication.CreateBuilder(args);

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

builder.Services.AddControllers(config =>
{
    config.RespectBrowserAcceptHeader = true;
    config.ReturnHttpNotAcceptable = true;
}).AddXmlDataContractSerializerFormatters()
  .AddCustomCSVFormatter();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.ConfigureLoggerService();

builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddDbContextPool<NesrinDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BookDb")));


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
