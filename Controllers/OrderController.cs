using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRO1Restaurant.Models;

namespace PRO1Restaurant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private pro1abdContext _context;
        public OrderController(pro1abdContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            var emps = _context.Order.ToList();

            return Ok(emps);
        }

        //api/order/4
        [HttpGet("{id:int}")]
        public IActionResult GetOrder(int OrderId)
        {
            var emps = _context.Order.ToList();

            return Ok(emps);
        }
    }
}