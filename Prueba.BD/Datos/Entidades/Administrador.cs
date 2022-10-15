using System.ComponentModel.DataAnnotations;

namespace Prueba.BD.Datos.Entidades
{
    public  class Administrador
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="El campo nombre es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage ="El campo numero de telefono es obligatorio")]
        public string NumeroTelefono { get; set; }

        public List<Proveedor> Proveedores { get; set; }
    }
}
