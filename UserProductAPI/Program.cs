using Microsoft.EntityFrameworkCore;
using UserProductAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure DbContext for SQL Server connection
builder.Services.AddDbContext<UserProductDbContext>(options =>
    options.UseSqlServer("Data Source=AMR_ROG\\SQLEXPRESS05;Initial Catalog=TestDB;Integrated Security=True;TrustServerCertificate=True"));

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
