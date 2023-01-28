using MediatR;
using Web_API.Models;

namespace Web_API.Data.Commands
{
    public class CreateCategoryCommand:IRequest<Category>
    {
        public string Name { get; set; }


    }
}
