using Kata.Application;
using Kata.Application.Order.Interfaces;
using Kata.Infrastructure;
using Kata.Infrastructure.Clients;
using Kata.Persistence;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure();
builder.Services.AddPersistence(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddApplication();

builder.Services.AddHttpClient<IOrderHttpClient, OrderHttpClient>(c => { c.BaseAddress = new Uri(builder.Configuration["ApiSettings:Address"]); });

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