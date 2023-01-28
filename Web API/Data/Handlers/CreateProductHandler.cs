using AutoMapper;
using MediatR;
using Web_API.Data.Commands;
using Web_API.Data.Context;
using Web_API.Models;

namespace Web_API.Data.Handlers
{
    public class CreateProductHandler:IRequestHandler<CreateProductCommand,Product>
    {
        private BaseRepository<Product,MediatorContext> _productDal;
        private readonly IMapper _mapper;

        public CreateProductHandler(BaseRepository<Product, MediatorContext> productDal, IMapper mapper)
        {
            _productDal = productDal;
            _mapper = mapper;
        }

        public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Product mappedProduct = _mapper.Map<Product>(request);
            Product addedProduct = await _productDal.AddAsync(mappedProduct);
            return addedProduct;
        }
    }
}
