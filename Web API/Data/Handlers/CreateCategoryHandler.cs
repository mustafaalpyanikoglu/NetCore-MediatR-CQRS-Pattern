using MediatR;
using Web_API.Data.Commands;
using Web_API.Models;

namespace Web_API.Data.Handlers
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand,Category>
    {
        private BaseRepository<Category> _categoryDal;

        public CreateCategoryHandler(BaseRepository<Category> categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public async Task<Category> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category addedCategory = await _categoryDal.AddAsync(request.Category);
            return addedCategory;
        }
    }
}
