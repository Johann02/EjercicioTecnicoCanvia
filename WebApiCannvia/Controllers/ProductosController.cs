using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiCannvia.Data;
using WebApiCannvia.Models;

namespace WebApiCannvia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly WebApiCannviaContext _context;

        public ProductosController(WebApiCannviaContext context)
        {
            _context = context;
        }

        // GET: api/Productos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProducto()
        {
            var _productos = await _context.SP_Producto_Get();
            return _productos;
        }

        // GET: api/Productos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProductoId(int id)
        {
            var producto = await _context.SP_Producto_Get_Id(id);

            if (producto == null)
            {
                return NotFound();
            }

            return producto;
        }

        // GET: api/Productos/Categoria/5
        [HttpGet("Categoria/{idcategoria}")]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductoCategoria(int idCategoria)
        {
            var producto = await _context.SP_Producto_Get_Categoria(idCategoria);

            if (producto == null)
            {
                return NotFound();
            }

            return producto;
        }

        // PUT: api/Productos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, Producto producto)
        {
            if (id != producto.Id)
            {
                return BadRequest();
            }

            await _context.SP_Producto_Put(id, producto.IdCategoria, producto.Nombre, producto.Descripcion, producto.Unidades);

            return NoContent();
        }

        // POST: api/Productos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Producto>> PostProducto(Producto producto)
        {
            var _producto = await _context.SP_Producto_Post(producto.IdCategoria, producto.Nombre, producto.Descripcion, producto.Unidades);
            if (_producto == null)
            {
                return NotFound();
            }
            return _producto;
        }

        // DELETE: api/Productos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            await _context.SP_Producto_Delete(id);

            return NoContent();
        }

        // DELETE: api/Productos/Delete/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteLogicoProducto(int id)
        {
            await _context.SP_Producto_Delete_Logico(id);
            
            return NoContent();
        }

    }
}
