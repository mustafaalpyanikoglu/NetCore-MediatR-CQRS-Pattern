using MediatR;
using Web_API.Models;

namespace Web_API.Data.Queries
{
    public class GetListProductQuery:IRequest<List<Product>>
    {
    }
}
