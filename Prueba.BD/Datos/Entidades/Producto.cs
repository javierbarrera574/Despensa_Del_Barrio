using System.ComponentModel.DataAnnotations;


namespace Prueba.BD.Datos.Entidades
{
    public class Producto
    {
        public int Id { get; set; }

        [Required]
        public string NombreProducto { get; set; }

        [Required]
        public string DescripcionProducto { get; set; }

        public string FechaVencimiento { get; set; }


        [Required]

        public string PrecioProducto { get; set; }

        public List<Proveedor> Proveedores { get; set; }

    }
}
