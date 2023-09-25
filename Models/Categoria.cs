using System.ComponentModel.DataAnnotations;

namespace projectef.Models;

public class Categoria
{
    [Key]
    public Guid CategoriaId { get; set; }

    [Required]
    public string Nombre { get; set; }

    public string Descripcion { get; set; }

    public virtual ICollection<Tarea> Tareas { get; set; }


}
