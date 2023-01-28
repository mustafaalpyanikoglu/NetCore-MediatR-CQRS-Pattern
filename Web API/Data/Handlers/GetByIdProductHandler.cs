using MediatR;
using Web_API.Data.Context;
using Web_API.Data.Queries;
using Web_API.Models;

namespace Web_API.Data.Handlers
{
    public class GetByIdProductHandler : IRequestHandler<GetByIdProductQuery, Product>
    {
        private BaseRepository<Product,MediatorContext> _productDal;

        public GetByIdProductHandler(BaseRepository<Product, MediatorContext> productDal)
        {
            _productDal = productDal;
        }

        public async Task<Product> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
        {
            Product? product = await _productDal.GetByAsync(p => p.Id == request.Id);
            return product ?? new Product();
        }
    }
}
