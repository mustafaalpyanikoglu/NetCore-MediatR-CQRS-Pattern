using MediatR;
using Web_API.Data.Queries;
using Web_API.Models;

namespace Web_API.Data.Handlers
{
    public class GetByIdProductHandler : IRequestHandler<GetByIdProductQuery, Product>
    {
        private BaseRepository<Product> _productDal;

        public GetByIdProductHandler(BaseRepository<Product> productDal)
        {
            _productDal = productDal;
        }

        public async Task<Product> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
        {
            Product product = await _productDal.GetByIdAsync(request.Id);
            return product;
        }
    }
}
