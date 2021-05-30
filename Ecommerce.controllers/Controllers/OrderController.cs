using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.models;
using Ecommerce.services.interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Ecommerce.controllers.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            this._orderService = orderService;
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<Order>> GetOrders()
        {
            try
            {
                IEnumerable<Order> orders = this._orderService.GetAll();
                return Ok(orders);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Order> GetOrderById(int id)
        {
            try
            {
                Order order = this._orderService.GetById(id);
                return Ok(order);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("")]
        public ActionResult<Order> PostOrder(Order newOrder)
        {
            try
            {
                Order order = new Order();
                order = newOrder;
                this._orderService.Create(order);
                return Ok(order);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        public IActionResult PutOrder(int id, Order updateOrder)
        {
            try
            {
                Order order = this._orderService.GetById(id);
                order = updateOrder;
                this._orderService.Update(order);
                return Ok();
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Order> DeleteOrderById(int id)
        {
            try
            {
                this._orderService.Delete(id);
                return Ok();
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }
    }
}