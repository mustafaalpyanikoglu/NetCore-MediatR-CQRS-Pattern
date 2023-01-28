using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_API.Data.Commands;
using Web_API.Data.Queries;
using Web_API.Models;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private IMediator _mediator;

        public ProductController(ILogger<ProductController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            GetListProductQuery query = new GetListProductQuery();
            List<Product> result = await _mediator.Send(query);
            return result.Count != 0 ? (IActionResult)Ok(result) : BadRequest();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetGame(int id)
        {
            GetByIdProductQuery query = new GetByIdProductQuery(id);
            Product result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            CreateProductCommand query = new CreateProductCommand(product);
            var result = await _mediator.Send(query);
            return result != null ? Ok(result) : BadRequest();
        }
    }
}
