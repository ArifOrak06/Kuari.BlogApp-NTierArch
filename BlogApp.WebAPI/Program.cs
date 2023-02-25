using BlogApp.Core.Repositories;
using BlogApp.Core.Services;
using BlogApp.Core.UnitOfWork;
using BlogApp.Repository.Contexts;
using BlogApp.Repository.Repositories;
using BlogApp.Repository.UnitOfWork;
using BlogApp.Service.Mappings.AutoMapper;
using BlogApp.Service.Services;
using BlogApp.Service.Validations;
using BlogApp.WebAPI.Filters;
using BlogApp.WebAPI.Middlewares;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers( opt =>
{
    opt.Filters.Add(new ValidateFilterAttribute());
}).AddFluentValidation(x =>
{
    x.RegisterValidatorsFromAssemblyContaining<ArticleCreateDtoValidator>();
});

builder.Services.AddScoped(typeof(IService<,,,>), typeof(Service<,,,>));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
builder.Services.AddDbContext<BlogAppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), options =>
    {
        options.MigrationsAssembly(Assembly.GetAssembly(typeof(BlogAppDbContext)).GetName().Name);
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCustomException();

app.UseAuthorization();

app.MapControllers();

app.Run();
