
using Microsoft.EntityFrameworkCore;
using projectef.Models;

namespace projectef;

public class TareasContext : DbContext
{
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Tarea> Tareas { get; set; }

    //Constructor que recibe las diferentes opciones 
    public TareasContext(DbContextOptions<TareasContext> options) :base(options){}
    
}
