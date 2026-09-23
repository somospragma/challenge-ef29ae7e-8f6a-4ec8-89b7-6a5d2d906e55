using MediatR;
using Microsoft.AspNetCore.Mvc;
using Orders.Application.Queries.GetOrderById;
using Orders.Application.Queries.GetOrdersByCustomer;
using Orders.Application.Queries.GetOrdersByStatus;
using Orders.Application.Queries.GetOrdersByDateRange;

namespace Orders.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersQueryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersQueryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetOrderById(Guid id)
        {
            var order = await _mediator.Send(new GetOrderByIdQuery { Id = id });
            return order == null? NotFound() : Ok(order);
        }

        [HttpGet("customer/{customerId}")]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrdersByCustomerId(Guid customerId)
        {
            var orders = await _mediator.Send(new GetOrdersByCustomerQuery { CustomerId = customerId });
            return Ok(orders);
        }

        [HttpGet("status/{status}")]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrdersByStatus(OrderStatus status)
        {
            var orders = await _mediator.Send(new GetOrdersByStatusQuery { Status = status });
            return Ok(orders);
        }

        [HttpGet("date/{startDate}/{endDate}")]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrdersByDateRange(DateTime startDate, DateTime endDate)
        {
            var orders = await _mediator.Send(new GetOrdersByDateRangeQuery { StartDate = startDate, EndDate = endDate });
            return Ok(orders);
        }
    }
}