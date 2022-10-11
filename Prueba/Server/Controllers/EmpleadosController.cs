using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prueba.BD.Datos;
using Prueba.BD.Datos.Entidades;

namespace Prueba.Server.Controllers
{
    [ApiController]
    [Route("Empleados")]
    public class EmpleadosController : ControllerBase
    {
        private readonly AplicacionDbContext context;
        public EmpleadosController(AplicacionDbContext Context)
        {
            this.context = Context;
        }





        [HttpGet]
        public async Task<ActionResult<List<Empleado>>> Get()
        {

            var registro = await context.Empleados.ToListAsync();

            return registro;

        }



        public async Task<ActionResult<int>> post(Empleado empleado)
        {
            try
            {

                context.Add(empleado);
                await context.SaveChangesAsync();
                return empleado.Id;

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("id:int")]

        public async Task<ActionResult<Empleado>> GetBuscar(int id)
        {

            var empleado = await context.Empleados.
                Where(x => x.Id == id).
                FirstOrDefaultAsync();

            if (empleado is null)
            {
                return NotFound($"No se encontro el empleado de Id: {id}");
            }

            return empleado;
        }


        [HttpPut("id:int")]

        public ActionResult PutActualizar(int id, [FromBody] Empleado empleado)
        {
            if (id != empleado.Id)
            {
                return BadRequest("No se encontro el empleado");
            }


            var registro = context.Empleados.Where(x => x.Id == id).FirstOrDefault();


            if (registro is null)
            {
                return NotFound("No existe el empleado a modificar");
            }



            registro.Nombre = empleado.Nombre;
            registro.Apellido = empleado.Apellido;
            registro.Edad = empleado.Edad;




            try
            {

                context.Empleados.Update(registro);
                context.SaveChanges();
                return Ok();

            }
            catch (Exception e)
            {
                return BadRequest($"No se pudo actualizar el empleado por: {e.Message}");
            }

        }

        [HttpDelete]

        public ActionResult delete(int id)
        {
            var registro = context.Empleados.Where(x => x.Id == id).FirstOrDefault();

            if (registro is null)
            {
                return NotFound($"El empleado de Id=  {id}, no fue encontrado");
            }


            try
            {
                context.Remove(registro);
                context.SaveChanges();
                return Ok($"El nombre: {registro.Nombre} del empleado ha sido eliminado");
            }
            catch (Exception e)
            {

                return BadRequest($"El registro no pudo eliminarse por: {e.Message}");

            }
        }

    }

}
