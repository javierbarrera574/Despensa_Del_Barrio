using System.ComponentModel.DataAnnotations;

namespace Prueba.BD.Datos.Entidades
{
    public  class Administrador
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string NumeroTelefono { get; set; }

        public List<Proveedor> Proveedores { get; set; }
    }
}
