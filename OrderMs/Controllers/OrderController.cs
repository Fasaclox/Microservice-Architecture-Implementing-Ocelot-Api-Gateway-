using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderMs.Context;
using OrderMs.Models;
using System.Collections.Generic;
using System.Linq;

namespace OrderMs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private OrderContext _orderContext;

        public OrderController(OrderContext orderContext)
        {
            _orderContext = orderContext;
        }

        // GET: api/<OrderController>
        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return _orderContext.Orders;
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public Order Get(int id)
        {
            return _orderContext.Orders.FirstOrDefault(s => s.Id == id);
        }

        // POST api/<OrderController>
        [HttpPost]
        public void Post([FromBody] Order value)
        {
            _orderContext.Orders.Add(value);
            _orderContext.SaveChanges();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Order value)
        {
            var order = _orderContext.Orders.FirstOrDefault(s => s.Id == id);
            if (order != null)
            {
                _orderContext.Entry<Order>(order).CurrentValues.SetValues(value);
                _orderContext.SaveChanges();
            }
        }
        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var order = _orderContext.Orders.FirstOrDefault(s => s.Id == id);
            if (order != null)
            {
                _orderContext.Orders.Remove(order);
                _orderContext.SaveChanges();
            }
        }
    }
}
