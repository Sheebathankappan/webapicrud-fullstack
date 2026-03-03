using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPICRUD.Models;
using WebAPICRUD.Data;
using Microsoft.EntityFrameworkCore;
using Azure;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Identity.Client;
using WebAPICRUD.DTO;

namespace WebAPICRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public ProductsController(AppDbContext dbContext)
        {
                _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Product product)
        {
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new {id=1}, product);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await  _dbContext.Products.AsNoTracking().ToListAsync());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int  id)
        {
            if (id == 0) { return BadRequest(); }
            var product = _dbContext.Products.SingleOrDefault(p => p.Id == id);
            return Ok(product);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Product product)
        {
            var existing = await _dbContext.Products.FindAsync(id);
            if (existing == null) { return NotFound(); }
            existing.Name = product.Name;
            existing.Price = product.Price;
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _dbContext.Products.FindAsync(id);
            if (product == null) return NotFound();
            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id,
            [FromBody] JsonPatchDocument<Product> patchDoc)
        {
            var product = await _dbContext.Products.FindAsync(id);

            if (product == null) return NotFound();

            patchDoc.ApplyTo(product,ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            _dbContext.Entry(product).State = EntityState.Modified;
            Console.WriteLine(product.Price);
            var entry = _dbContext.Entry(product).State;
            var re=await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost("NoTrack")]
        public async Task<IActionResult> Update([FromBody]UpdateProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //if (productDto == null) return BadRequest();

            var exists=_dbContext.Products.AsNoTracking().AnyAsync(p=>p.Id == productDto.Id);
            if (!await exists) return NotFound();

            var product = new Product
            {
                Id = productDto.Id,
                Price = productDto.Price,
            };

            _dbContext.Attach(product);
            _dbContext.Entry(product).Property(p=>p.Price).IsModified = true;
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost("NoTrack1")]
        public async Task<IActionResult> Update1([FromBody]UpdateProductDto productDto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var existing=await _dbContext.Products.FindAsync(productDto.Id);
            if(existing==null) return NotFound();
            existing.Price = productDto.Price;
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

    }
}
