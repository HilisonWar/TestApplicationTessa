using TestApplicationTessa.Models;
using Microsoft.EntityFrameworkCore;
using TestApplicationTessa.Services.Interfaces;
using TestApplicationTessa.Services;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Internal;
using TestApplicationTessa.Repositories.Interfaces;
using TestApplicationTessa.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews()
	 .AddNewtonsoftJson(options =>
	options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.IncludeXmlComments(Path.Combine(
        AppContext.BaseDirectory,
        $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"), true);

});


builder.Services.AddTransient<IDocumentsRepository, DocumentsRepository>();

builder.Services.AddTransient<ITasksRepository, TasksRepository>();

builder.Services.AddDbContext<DataBaseContext>(options =>
	options.UseSqlite(builder.Configuration.GetConnectionString("DB"))
	);

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
