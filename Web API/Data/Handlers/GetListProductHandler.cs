using MediatR;
using Web_API.Data.Context;
using Web_API.Data.Queries;
using Web_API.Models;

namespace Web_API.Data.Handlers
{
    public class GetListProductHandler : IRequestHandler<GetListProductQuery, List<Product>>
    {
        private BaseRepository<Product, MediatorContext> _productDal;

        public GetListProductHandler(BaseRepository<Product, MediatorContext> productDal)
        {
            _productDal = productDal;
        }

        public async Task<List<Product>> Handle(GetListProductQuery request, CancellationToken cancellationToken)
        {
            List<Product> products = await _productDal.GetAllAsync();
            return products;
        }
    }
}
