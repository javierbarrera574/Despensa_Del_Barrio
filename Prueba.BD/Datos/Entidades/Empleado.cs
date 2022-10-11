using System.ComponentModel.DataAnnotations;


namespace Prueba.BD.Datos.Entidades
{
    public  class Empleado
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]

        public string Edad { get; set; }
    }
}
