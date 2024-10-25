using Microsoft.EntityFrameworkCore;
using PracticaProgramada2_Grupo8.Data;

var builder = WebApplication.CreateBuilder(args);

//Add conexion to the server
//"ConnectionString": {
//"ConexionBD": "Server=srv863.hstgr.io;Port=3306;User=u484426513_pac324;Password=B&XWouC#9Ef;Database=u484426513_pac324;"
//},
var connectionString = builder.Configuration.GetConnectionString("ConexionBD");

//Add to the service
builder.Services.AddDbContext<ConexionBbContext>(
    options =>
    options.UseMySql(connectionString, new MySqlServerVersion( new Version (8, 0, 21) )

    ));
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
