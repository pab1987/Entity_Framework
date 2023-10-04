
using Microsoft.EntityFrameworkCore;
using projectef.Models;

namespace projectef;

public class TareasContext : DbContext
{
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Tarea> Tareas { get; set; }

    //Constructor que recibe las diferentes opciones 
    public TareasContext(DbContextOptions<TareasContext> options) : base(options) { }



    //Se reescribe el método para poder manejar mediante Fluent API los DataAnnotations
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Categoria> categoriaInit = new List<Categoria>();

        categoriaInit.Add(new Categoria()
        {
            CategoriaId = Guid.Parse("66899106-603d-447c-99ce-8fcaa32398e7"),
            Nombre = "Actividades pendientes",
            Peso = 20
        });

        categoriaInit.Add(new Categoria()
        {
            CategoriaId = Guid.Parse("66899106-603d-447c-99ce-8fcaa3239802"),
            Nombre = "Actividades personales",
            Peso = 50
        });

        modelBuilder.Entity<Categoria>(categoria =>
        {
            categoria.ToTable("Categoria");
            categoria.HasKey(p => p.CategoriaId);
            categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
            categoria.Property(p => p.Descripcion).IsRequired(false);
            categoria.Property(p => p.Peso);

            categoria.HasData(categoriaInit);
        });

        List<Tarea> tareasInit = new List<Tarea>();
        tareasInit.Add(new Tarea()
        {
            tareaId = Guid.Parse("66899106-603d-447c-99ce-8fcaa3239810"),
            CategoriaId = Guid.Parse("66899106-603d-447c-99ce-8fcaa32398e7"),
            PrioridadTarea = Prioridad.Media,
            Titulo = "Pago servicios publicos",
            FechaCreacion = DateTime.UtcNow,
            EstadoTarea = true
        });

        tareasInit.Add(new Tarea()
        {
            tareaId = Guid.Parse("66899106-603d-447c-99ce-8fcaa3239820"),
            CategoriaId = Guid.Parse("66899106-603d-447c-99ce-8fcaa3239802"),
            PrioridadTarea = Prioridad.Baja,
            Titulo = "Hacer los deberes de la casa",
            FechaCreacion = DateTime.UtcNow,

            EstadoTarea = false
        });

        modelBuilder.Entity<Tarea>(tarea =>
        {
            tarea.ToTable("Tarea");
            tarea.HasKey(p => p.tareaId);
            tarea.HasOne(p => p.Categoria).WithMany(p => p.Tareas).HasForeignKey(p => p.CategoriaId);
            tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(200);
            tarea.Property(p => p.Descripcion).IsRequired(false);
            tarea.Property(p => p.PrioridadTarea).IsRequired();
            tarea.Property(p => p.FechaCreacion).HasDefaultValue(DateTime.Now);
            tarea.Ignore(p => p.Resumen);
            tarea.Property(p => p.EstadoTarea).IsRequired();

            tarea.HasData(tareasInit);

        });
    }

}
