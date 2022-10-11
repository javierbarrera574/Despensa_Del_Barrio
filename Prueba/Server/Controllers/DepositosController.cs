using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prueba.BD.Datos;
using Prueba.BD.Datos.Entidades;

namespace Prueba.Server.Controllers
{

    [ApiController]
    [Route("api/Depositos")]
    public class DepositosController : ControllerBase
    {
        private readonly AplicacionDbContext context;
        public DepositosController(AplicacionDbContext Context)
        {
            this.context = Context;
        }


        [HttpGet]
        public async Task<ActionResult<List<Deposito>>> Get()
        {
            var respuesta = await context.Depositos.ToListAsync();

            return respuesta;
        }


        [HttpPost]

        public async Task<ActionResult<int>> post(Deposito deposito)
        {
            try
            {
                context.Depositos.Add(deposito);
                await context.SaveChangesAsync();
                return deposito.Id;//Es devuelto con el id asignado

            }
            catch (Exception p)
            {
                return BadRequest(p.Message);
            }
        }

        [HttpPut("id:int")]

        public ActionResult PutActualizar(int id, [FromBody] Deposito deposito)
        {
            if (id != deposito.Id)
            {
                return BadRequest("No se encontro el registro");
            }


            var registro = context.Depositos.Where(x => x.Id == id).FirstOrDefault();

            //como la categoria esta en la base de datos dentro de registro
            //y categoria es como quiero que quede despues de hacer la modificacion

            if (registro is null)
            {
                return NotFound("No existe el numero de deposito a modificar");
            }


            //actualizacion de los objetos que hay en la base de datos con los que hay en el cuerpo(body)

            registro.CodigoEstante = deposito.CodigoEstante;
            registro.CategoriaEnEstante = deposito.CategoriaEnEstante;
            registro.CantidadEnEstante = deposito.CantidadEnEstante;


            try
            {

                context.Depositos.Update(registro);//si mando aca dentro de update, al objeto categorias, no va a haber conexion con la base de datos
                context.SaveChanges();
                return Ok();

            }
            catch (Exception e)
            {
                return BadRequest($"Los datos no han podido ser actualizados, por el siguiente error: {e.Message}");
            }
        }



        [HttpDelete("id:int")]


        public ActionResult Borrar(int id)
        {

            var registro = context.Depositos.Where(x => x.Id == id).FirstOrDefault();

            if (registro is null)
            {
                return NotFound($"El deposito de id: {id} no fue encontrado");
            }


            try
            {
                context.Remove(registro);
                context.SaveChanges();
                return Ok($"El numero de estante: {registro.CodigoEstante} ha sido eliminado");
            }
            catch (Exception e)
            {

                return BadRequest($"El numero de estante no pudo eliminarse por: {e.Message}");

            }

        }

        [HttpGet("id:int")]

        public async Task<ActionResult<Deposito>> GetBuscar(int id)
        {

            var deposito = await context.Depositos.
                Where(x => x.Id == id).
                FirstOrDefaultAsync();

            if (deposito is null)
            {
                return NotFound($"No se encontro el numero de deposito de Id: {id}");
            }

            return deposito;


        }
    }

}
