using MediatR;
using Web_API.Data.Context;
using Web_API.Data.Queries;
using Web_API.Models;

namespace Web_API.Data.Handlers
{
    public class GetListCategoryHandler : IRequestHandler<GetListCategoryQuery, List<Category>>
    {
        private BaseRepository<Category,MediatorContext> _categoryDal;

        public GetListCategoryHandler(BaseRepository<Category, MediatorContext> categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public Task<List<Category>> Handle(GetListCategoryQuery request, CancellationToken cancellationToken)
        {
            List<Category> categories = _categoryDal.GetAll();
            return Task.FromResult(categories);
        }
    }
}
