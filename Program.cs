using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectef;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using projectef;

var builder = WebApplication.CreateBuilder(args);

//Así se crea una base de datos en memoria
//builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("TareaDb"));

//Conexion a base de datos PostgreSQL
//var connectionString = "Host=localhost;Port=5432;Database=pablo;Username=pablo;Password=010687";


builder.Services.AddNpgsql<TareasContext>(builder.Configuration.GetConnectionString("conTareas"));

var app = builder.Build();

app.MapGet("/dbconexion", () => Results.Ok("Conexión exitosa a la base de datos PostgreSQL"));

// Otra ruta para verificar el estado de la base de datos en memoria
/* app.MapGet("/dbconexion-memoria", async ([FromServices] TareasContext dbContext) =>
{
    if (dbContext.Database.IsInMemory())
    {
        return Results.Ok("Base de datos creada en memoria");
    }
    else
    {
        return Results.Problem("La base de datos no está en memoria");
    }
}); */

app.Run();
