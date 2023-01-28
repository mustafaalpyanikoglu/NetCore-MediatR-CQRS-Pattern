using AutoMapper;
using MediatR;
using Web_API.Data.Commands;
using Web_API.Data.Context;
using Web_API.Models;

namespace Web_API.Data.Handlers
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand,Category>
    {
        private BaseRepository<Category,MediatorContext> _categoryDal;
        private readonly IMapper _mapper;

        public CreateCategoryHandler(BaseRepository<Category, MediatorContext> categoryDal, IMapper mapper)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
        }

        public async Task<Category> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category mappedCategory = _mapper.Map<Category>(request);
            Category addedCategory = await _categoryDal.AddAsync(mappedCategory);
            return addedCategory;
        }
    }
}
