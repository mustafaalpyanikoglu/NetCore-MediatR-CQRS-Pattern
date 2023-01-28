using MediatR;
using Web_API.Data.Queries;
using Web_API.Models;

namespace Web_API.Data.Handlers
{
    public class GetListCategoryHandler : IRequestHandler<GetListCategoryQuery, List<Category>>
    {
        private BaseRepository<Category> _categoryDal;

        public GetListCategoryHandler(BaseRepository<Category> categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public async Task<List<Category>> Handle(GetListCategoryQuery request, CancellationToken cancellationToken)
        {
            List<Category> categories = await _categoryDal.GetAllAsync();
            return categories;
        }
    }
}
