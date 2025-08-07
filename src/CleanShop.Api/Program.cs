using CleanShop.Infra.Data;
using Microsoft.EntityFrameworkCore;
using CleanShop.Application;
using CleanShop.Application.Interfaces;
using CleanShop.Application.Interfaces.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RegisterDatabaseServices(builder.Configuration);
builder.Services.RegisterApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(option =>
{
    option.AllowAnyHeader()
          .AllowAnyMethod()
          .AllowCredentials()
          .WithOrigins("http://localhost:3000");
});
app.UseAuthorization();

app.MapControllers();

var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<IApplicationDbContext>();
var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

try
{
    context.Database.Migrate();
    await DbInitializer.Initialize(context);
}
catch (Exception ex)
{
    logger.LogError(ex, "A problem occurred during migration.");
}



app.Run();
