using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prueba.BD.Datos;
using Prueba.BD.Datos.Entidades;

namespace Prueba.Server.Controllers
{
    [ApiController]
    [Route("Proveedores")]
    public class ProveedoresController : ControllerBase
    {

        private readonly AplicacionDbContext context;
        public ProveedoresController(AplicacionDbContext Context)
        {
            this.context = Context;
        }

        [HttpGet]

        public async Task<ActionResult<List<Proveedor>>> Get()
        {

            var respuesta = await context.Proveedores.ToListAsync();
            return respuesta;

        }


        [HttpPost]
        public async Task<ActionResult<int>> Post(Proveedor proveedores)
        {
            try
            {
                context.Proveedores.Add(proveedores);
                await context.SaveChangesAsync();
                return proveedores.Id;
            }
            catch (Exception e)
            {

                return BadRequest($"No se pudo agregar el proveedor por: {e.Message} ");
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, [FromBody] Proveedor proveedores)
        {


            if (id != proveedores.Id)
            {
                return BadRequest("Datos incorrectos");
            }

            var registro = context.Proveedores.Where(e => e.Id == id).FirstOrDefault();

            if (registro is null)
            {
                return NotFound("No existe el proveedor a modificar");
            }

            registro.Nombre = proveedores.Nombre;
            registro.CorreoElectronico = proveedores.CorreoElectronico;
            registro.NumeroTelefono = proveedores.NumeroTelefono;


            try
            {

                context.Proveedores.Update(registro);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"El proveedor no se pudo actualizar por: {e.Message}");
            }

        }



        [HttpDelete("{id}")]

        public ActionResult PostBorrar(int id)
        {
            var Proveedor = context.Proveedores.Where(x => x.Id == id).FirstOrDefault();


            if (Proveedor is null)
            {
                return BadRequest($"El proveedor de Id= {id}, no fue encontrado para ser borrado");
            }


            try
            {
                context.Remove(Proveedor);
                context.SaveChanges();
                return Ok($"El producto de nombre={Proveedor.Nombre} ha sido borrado.");
            }
            catch (Exception error)
            {
                return BadRequest($"El proveedor no pudo eliminarse: {error.Message}");
            }
        }

        [HttpGet("id:int")]

        public async Task<ActionResult<Proveedor>> GetBuscar(int id)
        {

            var proveedor = await context.Proveedores.
                Where(x => x.Id == id).
                //Include(p=>p.Productos).
                FirstOrDefaultAsync();

            if (proveedor is null)
            {
                return NotFound($"No se encontro el proveedor de Id= {id}");
            }

            return proveedor;


        }

    }
}
