using System.ComponentModel.DataAnnotations;

namespace Prueba.BD.Datos.Entidades
{
    public class Categoria
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="El campo tipo de categoria es obligatorio")]

        public string TipoCategoria { get; set; }


        [Required(ErrorMessage ="El campo codigo de categoria es obligatorio")]

        public string CodigoCategoria { get; set; }

        public List<Producto> Productos { get; set; }
    }
}
