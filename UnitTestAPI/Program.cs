using Microsoft.EntityFrameworkCore;
using UnitTestAPI.Data;
using UnitTestAPI.Service;

var builder = WebApplication.CreateBuilder(args);

// Connection
var conString = @"Server=REAKKIDINGG;Database=ApiTesting;User Id=vireak;Password=0412;TrustServerCertificate=true";
builder.Services.AddDbContext<AppDbContext>(o => o.UseSqlServer(conString));
//Di
builder.Services.AddTransient<ICategoryService, CategoryService>();



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
