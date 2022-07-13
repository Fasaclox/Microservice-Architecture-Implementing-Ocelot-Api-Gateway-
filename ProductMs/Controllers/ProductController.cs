using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductMs.Context;
using ProductMs.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProductMs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // GET: ProductController
        private ProductContext _productContext;

        public ProductController(ProductContext productContext)
        {
            _productContext = productContext;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _productContext.Products;
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return _productContext.Products.FirstOrDefault(s => s.Id == id);
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] Product value)
        {
            _productContext.Products.Add(value);
            _productContext.SaveChanges();
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product value)
        {
            var product = _productContext.Products.FirstOrDefault(s => s.Id == id);
            if (product != null)
            {
                _productContext.Entry<Product>(product).CurrentValues.SetValues(value);
                _productContext.SaveChanges();
            }
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var product = _productContext.Products.FirstOrDefault(s => s.Id == id);
            if (product != null)
            {
                _productContext.Products.Remove(product);
                _productContext.SaveChanges();
            }
        }
    }
}
