using System.ComponentModel.DataAnnotations;


namespace Prueba.BD.Datos.Entidades
{
    public  class Empleado
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="El campo nombre del empleado es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage ="El campo apellido del empleado es obligatorio")]
        public string Apellido { get; set; }

        [Required(ErrorMessage ="El campo edad del empleado es obligatorio")]

        public string Edad { get; set; }
    }
}
