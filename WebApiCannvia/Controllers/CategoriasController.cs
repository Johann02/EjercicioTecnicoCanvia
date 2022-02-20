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
    public class CategoriasController : ControllerBase
    {
        private readonly WebApiCannviaContext _context;

        public CategoriasController(WebApiCannviaContext context)
        {
            _context = context;
        }

        // GET: api/Categorias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategoria()
        {

            var _categoria = await _context.SP_Categoria_Get();
            return _categoria;
        }

        // GET: api/Categorias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetCategoriaId(int id)
        {
            var categoria = await _context.SP_Categoria_Get_Id(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return categoria;
        }

        // PUT: api/Categorias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoria(int id, Categoria categoria)
        {
            if (id != categoria.Id)
            {
                return BadRequest();
            }

            await _context.SP_Categoria_Put(id, categoria.Nombre, categoria.Descripcion);

            return NoContent();
        }

        // POST: api/Categorias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Categoria>> PostCategoria(Categoria categoria)
        {
            var _categoria = await _context.SP_Categoria_Post(categoria.Nombre, categoria.Descripcion);
            if (_categoria == null)
            {
                return NotFound();
            }
            return _categoria;
        }

        // DELETE: api/Categorias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            await _context.SP_Categoria_Delete(id);

            return NoContent();
        }

        // DELETE: api/Categorias/Delete/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteLogicoCategoria(int id)
        {
            await _context.SP_Categoria_Delete_Logico(id);

            return NoContent();
        }

    }
}
