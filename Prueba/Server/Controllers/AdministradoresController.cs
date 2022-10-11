using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prueba.BD.Datos;
using Prueba.BD.Datos.Entidades;

namespace Prueba.Server.Controllers
{
    [ApiController]
    [Route("api/Administradores")]
    public class AdministradoresController : ControllerBase
    {
        private readonly AplicacionDbContext context;
        public AdministradoresController(AplicacionDbContext Context)
        {
            this.context = Context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Administrador>>> Get()
        {
            var respuesta = await context.Administradores.ToListAsync();

            return respuesta;
        }

        [HttpPost]

        public async Task<ActionResult<int>> Post(Administrador administrador)
        {
            try
            {
                context.Add(administrador);
                await context.SaveChangesAsync();
                return administrador.Id;
            }
            catch (Exception e)
            {
                return BadRequest($"No se pudo agregar el administrador por: {e.Message}");
            }
        }


        [HttpPut]

        public ActionResult Put(int id, [FromBody] Administrador administrador)
        {

            if (id != administrador.Id)
            {
                return BadRequest("No se encontro el registro");
            }


            var registro = context.Administradores.Where(x => x.Id == id).FirstOrDefault();


            if (registro is null)
            {
                return NotFound("No existe el administrador a modificar");
            }


            registro.Nombre = administrador.Nombre;
            registro.NumeroTelefono = administrador.NumeroTelefono;


            try
            {

                context.Administradores.Update(registro);
                context.SaveChanges();
                return Ok();

            }
            catch (Exception e)
            {
                return BadRequest($"No se pudo actualizar el administrador por: {e.Message}");
            }
        }

        [HttpDelete]

        public ActionResult Delete(int id)
        {
            var registro = context.Administradores.Where(x => x.Id == id).FirstOrDefault();

            if (registro is null)
            {
                return NotFound($"El registro {id} no fue encontrado");
            }


            try
            {
                context.Remove(registro);
                context.SaveChanges();
                return Ok($"El administrador: {registro.Nombre} ha sido eliminado");
            }
            catch (Exception e)
            {

                return BadRequest($"El administrador no pudo eliminarse por: {e.Message}");

            }
        }

        [HttpGet("id:int")]

        public async Task<ActionResult<Administrador>> GetBuscar(int id)
        {

            var administrador = await context.Administradores.
                Where(x => x.Id == id).
                FirstOrDefaultAsync();

            if (administrador is null)
            {
                return NotFound($"No se encontro el administrador de Id: {id}");
            }

            return administrador;


        }

    }
}
