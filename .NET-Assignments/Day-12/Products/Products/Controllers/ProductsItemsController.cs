using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Products.Models;

namespace Products.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsItemsController : ControllerBase
    {
        private readonly ProductsContext _context;

        public ProductsItemsController(ProductsContext context)
        {
            _context = context;
        }

        // GET: api/ProductsItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductsItem>>> GetProductsItems()
        {
            return await _context.ProductsItems.ToListAsync();
        }

        // GET: api/ProductsItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductsItem>> GetProductsItem(long id)
        {
            var productsItem = await _context.ProductsItems.FindAsync(id);

            if (productsItem == null)
            {
                return NotFound();
            }

            return productsItem;
        }

        // PUT: api/ProductsItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductsItem(long id, ProductsItem productsItem)
        {
            if (id != productsItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(productsItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ProductsItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductsItem>> PostProductsItem(ProductsItem productsItem)
        {
            _context.ProductsItems.Add(productsItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductsItem", new { id = productsItem.Id }, productsItem);
        }

        // DELETE: api/ProductsItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductsItem(long id)
        {
            var productsItem = await _context.ProductsItems.FindAsync(id);
            if (productsItem == null)
            {
                return NotFound();
            }

            _context.ProductsItems.Remove(productsItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductsItemExists(long id)
        {
            return _context.ProductsItems.Any(e => e.Id == id);
        }
    }
}
