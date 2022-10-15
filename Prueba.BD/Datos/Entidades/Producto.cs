using System.ComponentModel.DataAnnotations;


namespace Prueba.BD.Datos.Entidades
{
    public class Producto
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="El campo nombre del producto es obligatorio")]
        public string NombreProducto { get; set; }

        [Required(ErrorMessage ="El campo descripcion del producto es obligatorio")]
        public string DescripcionProducto { get; set; }

        [Required(ErrorMessage ="El campo fecha de vencimiento es obligatorio")]
        public string FechaVencimiento { get; set; }


        [Required(ErrorMessage ="El campo precio es obligatorio")]

        public string PrecioProducto { get; set; }

        public List<Proveedor> Proveedores { get; set; }

    }
}
