using MediatR;
using Web_API.Models;

namespace Web_API.Data.Commands
{
    public class CreateProductCommand:IRequest<Product>
    {
        public Product Product { get; set; }

        public CreateProductCommand(Product product)
        {
            this.Product = product;
        }
    }
}
