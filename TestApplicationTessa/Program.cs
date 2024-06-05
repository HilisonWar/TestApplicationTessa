using TestApplicationTessa.Models;
using Microsoft.EntityFrameworkCore;
using TestApplicationTessa.Services.Interfaces;
using TestApplicationTessa.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IDocumentsService, DocumentsService>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
