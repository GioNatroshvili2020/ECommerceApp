using System.Collections.Generic;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController:ControllerBase
    {
        private AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
          _context = context;
        }
         
        [HttpGet]
        public async  Task<ActionResult<List<Product>>>  GetProducts(){
            var products=await  _context.Products.ToListAsync();
     
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _context.Products.FindAsync(id);
            
        }

    } 
}