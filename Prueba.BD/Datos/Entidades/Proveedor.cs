using System.ComponentModel.DataAnnotations;


namespace Prueba.BD.Datos.Entidades
{
    public class Proveedor
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="El campo nombre del proveedor es obligatorio")]
        public string Nombre { get; set; }


        [Required(ErrorMessage ="El campo correo es obligatorio")]
        public string CorreoElectronico { get; set; }


        [Required(ErrorMessage ="El campo numero de telefono es obligatorio")]

        public string NumeroTelefono { get; set; }

    }
}
