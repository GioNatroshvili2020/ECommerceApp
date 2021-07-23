using System.Collections.Generic;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController:ControllerBase
    {
        private IproductRepository _repo;
         public ProductsController(IproductRepository repo)
        {
          _repo =repo;
        }
         
        [HttpGet]
        public async  Task<ActionResult<List<Product>>>  GetProducts(){
            var products=await  _repo.GetProductsAsync();
     
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _repo.GetProductByIdAsync(id);
            
        }

    } 
}