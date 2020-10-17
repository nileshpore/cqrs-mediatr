using CQRS_MediatR.Core.Handler.Queries;
using CQRS_MediatR.Core.Request.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_MediatR_POC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator mediator;
        public OrderController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        // GET: api/Order
        [HttpGet]
        public IActionResult Get()
        {
            var query = new GetAllOrdersQuery();
            var result = mediator.Send(query);
            return Ok(result);
        }



        // POST: api/Order
        [HttpPost]
        public IActionResult Post([FromBody] AddNewOrderCommand order)
        {
            var result = mediator.Send(order);
            return Ok(result);
        }


    }
}
