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
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;
        private IMediator _mediator;

        public CategoryController(ILogger<CategoryController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategorys()
        {
            GetListCategoryQuery query = new GetListCategoryQuery();
            List<Category> result = await _mediator.Send(query);
            return result.Count != 0 ? (IActionResult)Ok(result) : BadRequest();
        }


        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] Category Category)
        {
            CreateCategoryCommand query = new CreateCategoryCommand(Category);
            var result = await _mediator.Send(query);
            return result != null ? Ok(result) : BadRequest();
        }
    }
}
