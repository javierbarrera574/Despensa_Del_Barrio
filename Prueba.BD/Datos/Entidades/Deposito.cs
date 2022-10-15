using System.ComponentModel.DataAnnotations;

namespace Prueba.BD.Datos.Entidades
{
    public class Deposito
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="El campo codigo de estante es obligatorio")]

        public string CodigoEstante { get; set; }

        [Required(ErrorMessage ="El campo categoria del estante es obligatorio")]
        public string CategoriaEnEstante { get; set; }

        [Required(ErrorMessage ="El campo cantidad para el estante es obligatorio")]
        public string CantidadEnEstante { get; set; }

        public List<Producto> Productos { get; set; }
    }
}
