using Calculator.Application.Implementations;
using Calculator.Application.Interfaces;
using Calculator.Domain.Services.Implementations;
using Calculator.Domain.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register domain services
builder.Services.AddScoped<ICalculationService, CalculationService>();

// Register application services
builder.Services.AddScoped<ICalculationApplicationService, CalculationApplicationService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
