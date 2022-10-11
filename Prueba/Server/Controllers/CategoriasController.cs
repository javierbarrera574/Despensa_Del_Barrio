using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prueba.BD.Datos;
using Prueba.BD.Datos.Entidades;

namespace Prueba.Server.Controllers
{
    [ApiController]
    [Route("api/Categorias")]
    public class CategoriasController : ControllerBase
    {
        private readonly AplicacionDbContext context;

        public CategoriasController(AplicacionDbContext Contexto)
        {
            this.context = Contexto;

        }


        [HttpGet]//esta bien
        public async Task<ActionResult<List<Categoria>>> Get()
        {
            var respuesta = await context.Categorias.ToListAsync();
            return respuesta;
        }


        [HttpGet("id:int")]

        public async Task<ActionResult<Categoria>> GetBuscar(int id)
        {

            var categoria = await context.Categorias.
                Where(x => x.Id == id).
                FirstOrDefaultAsync();

            if (categoria is null)
            {
                return NotFound($"No se encontro la categoria de Id: {id}");
            }

            return categoria;


        }


        [HttpPost]

        public async Task<ActionResult<int>> post(Categoria categorias)
        {
            try
            {
                context.Add(categorias);
                await context.SaveChangesAsync();
                return categorias.Id;

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);

            }
        }

        [HttpPut("id:int")]

        public ActionResult PutActualizar(int id, [FromBody] Categoria categorias)
        {
            if (id != categorias.Id)
            {
                return BadRequest("No se encontro el registro");
            }


            var registro = context.Categorias.Where(x => x.Id == id).FirstOrDefault();

            //como la categoria esta en la base de datos dentro de registro
            //y categoria es como quiero que quede despues de hacer la modificacion

            if (registro is null)
            {
                return NotFound("No existe la categoria a modificar");
            }


            //actualizacion de los objetos que hay en la base de datos con los que hay en el cuerpo(body)

            registro.TipoCategoria = categorias.TipoCategoria;
            registro.CodigoCategoria = categorias.CodigoCategoria;


            try
            {

                context.Categorias.Update(registro);//si mando aca dentro de update, al objeto categorias, no va a haber conexion con la base de datos
                context.SaveChanges();
                return Ok();

            }
            catch (Exception e)
            {
                return BadRequest
                    ($"No se pudo actualizar la categoria por: {e.Message}");
            }

        }


        [HttpDelete("id:int")]


        public ActionResult Borrar(int id)
        {

            var registro = context.Categorias.Where(x => x.Id == id).FirstOrDefault();

            if (registro is null)
            {
                return NotFound($"El registro {id} no fue encontrado");
            }


            try
            {
                context.Remove(registro);
                context.SaveChanges();
                return Ok($"La categoria: {registro.TipoCategoria} ha sido eliminado");
            }
            catch (Exception e)
            {

                return BadRequest($"La categoria no pudo eliminarse por: {e.Message}");

            }

        }

    }


}
