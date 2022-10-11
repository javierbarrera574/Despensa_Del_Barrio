using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prueba.BD.Datos;
using Prueba.BD.Datos.Entidades;

namespace Prueba.Server.Controllers
{
    [ApiController]
    [Route("Productos")]
    public class ProductosController : ControllerBase
    {
        private readonly AplicacionDbContext context;
        public ProductosController(AplicacionDbContext Context)
        {
            this.context = Context;
        }



        [HttpGet]//esta bien
        public async Task<ActionResult<List<Producto>>> Get()
        {
            var respuesta = await context.Productos.ToListAsync();
            return respuesta;
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Producto>> Get(int id)
        {
            var producto = await context.Productos

                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();


            if (producto is null)

            {
                return NotFound($"No existe el Producto de Id= {id}");

            }

            return producto;

        }



        [HttpPost]

        public async Task<ActionResult<int>> PostAgregar(Producto productos)
        {
            try
            {
                context.Add(productos);
                await context.SaveChangesAsync();
                return productos.Id;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpDelete("{id:int}")]
        public ActionResult DeleteBorrar(int id)
        {
            var producto = context.Productos.Where(x => x.Id == id).FirstOrDefault();

            if (producto == null)
            {
                return NotFound($"El producto de Id= {id} no fue encontrado");
            }

            try
            {
                context.Productos.Remove(producto);
                context.SaveChanges();
                return Ok($"El producto de nombre={producto.NombreProducto} ha sido borrado.");
            }
            catch (Exception e)
            {
                return BadRequest($"El producto no pudo eliminarse por: {e.Message}");
            }
        }




        [HttpPut("{id:int}")]
        public ActionResult Put(int id, [FromBody] Producto productos)
        {
            if (id != productos.Id)
            {
                return BadRequest("Datos incorrectos");
            }

            var Productos = context.Productos.Where(e => e.Id == id).FirstOrDefault();

            //var proveedores = context.Proveedores.Where(m => m.Id == id).FirstOrDefaultAsync();

            if (Productos == null)
            {
                return NotFound("No existe el producto a modificar");
            }

            Productos.NombreProducto = productos.NombreProducto;
            Productos.DescripcionProducto = productos.DescripcionProducto;
            Productos.FechaVencimiento = productos.FechaVencimiento;
            Productos.PrecioProducto = productos.PrecioProducto;


            try
            {

                context.Productos.Update(Productos);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"El producto no se pudo actualizar por: {e.Message}");
            }
        }

    }
}
