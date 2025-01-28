using System.Reflection;
using BookManager.Api.Extensions;
using BookManager.Application.Base;
using BookManager.Application.Commands.Book.CreateOrUpdate;
using BookManager.Infrastructure.IoC;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RegisterInfrastructureDependencies();

builder.Services.AddMediatR(cfg => 
    cfg.RegisterServicesFromAssembly(Assembly.GetAssembly(typeof(BaseHandler<>))!));

builder.Services.AddValidatorsFromAssemblyContaining<CreateOrUpdateBookValidator>();

var app = builder.Build();

await app.Services.ExecuteMigrationAsync();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

BookEndpointsExtension.RegisterBookEndpoints(app);
app.RegisterUserEndpoints();

app.Run();