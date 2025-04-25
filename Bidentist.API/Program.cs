using MongoDB.Driver;
using bidendist.API.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// MongoDB Bağlantısı
builder.Services.AddSingleton<IMongoClient>(serviceProvider =>
    new MongoClient(builder.Configuration.GetConnectionString("MongoDBConnection"))
);

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
