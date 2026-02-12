using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products.Models;
using Products.DTOs;
using Products.Services;

namespace Products.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }
        // GET: api/productList
        [HttpGet]
        // public IActionResult GetAll
        public IActionResult GetAll()
        {
            var products = _service.GetAll()
                .Select(p => new ProductResponseDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    StockQuantity = p.StockQuantity,
                    Category = p.Category,
                    IsAvailable = p.IsAvailable,
                    IsExpensive = p.IsExpensive
                });

            return Ok(products);
        }

        // GET: api/productList/id
        [HttpGet("{id}")]
        // public IActionResult GetBy Id
        public IActionResult GetById(int id)
        {
            var p = _service.GetById(id);
            if (p == null) return NotFound();

            var dto = new ProductResponseDTO
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                StockQuantity = p.StockQuantity,
                Category = p.Category,
                IsAvailable = p.IsAvailable,
                IsExpensive = p.IsExpensive
            };

            return Ok(dto);
        }

        // POST: api/productList
        [HttpPost]
        // public IActionResult Post
        public IActionResult Create(ProductCreateDTO dto)
        {
            var product = new ProductsModel
            {
                Name = dto.Name,
                Price = dto.Price,
                StockQuantity = dto.StockQuantity,
                Category = dto.Category
            };

            var created = _service.Create(product);

            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        // Update Reservation
        [HttpPut("{id}")]
        // public IActionResult Update
        public IActionResult Update(int id, ProductUpdateDTO dto)
        {
            var updatedProduct = new ProductsModel
            {
                Name = dto.Name,
                Price = dto.Price,
                StockQuantity = dto.StockQuantity,
                Category = dto.Category
            };

            var success = _service.Update(id, updatedProduct);
            if (!success) return NotFound();

            return NoContent();
        }

        // public IActionResult PartialUpdate
        [HttpPatch("{id}/price")]
        public IActionResult UpdatePrice(int id, [FromBody] decimal price)
        {
            var success = _service.UpdatePrice(id, price);
            if (!success) return BadRequest("Invalid product or price.");

            return NoContent();
        }
        // Delete Product
        [HttpDelete("{id}")]
        // public IActionResult Delete
        public IActionResult Delete(int id)
        {
            var success = _service.Delete(id);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}
