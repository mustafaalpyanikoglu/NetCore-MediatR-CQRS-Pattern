using MediatR;
using Web_API.Data.Commands;
using Web_API.Models;

namespace Web_API.Data.Handlers
{
    public class CreateProductHandler:IRequestHandler<CreateProductCommand,Product>
    {
        private BaseRepository<Product> _productDal;

        public CreateProductHandler(BaseRepository<Product> productDal)
        {
            _productDal = productDal;
        }

        public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Product addedProduct = await _productDal.AddAsync(request.Product);
            return addedProduct;
        }
    }
}
