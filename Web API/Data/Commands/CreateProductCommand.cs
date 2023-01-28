using MediatR;
using Web_API.Models;

namespace Web_API.Data.Commands
{
    public class CreateProductCommand:IRequest<Product>
    {
        public string Name { get; set; }
        public double Price { get; set; }

    }
}
