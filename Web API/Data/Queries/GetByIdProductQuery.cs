using MediatR;
using Web_API.Models;

namespace Web_API.Data.Queries
{
    public class GetByIdProductQuery : IRequest<Product>
    {
        public int Id { get; set; }

        public GetByIdProductQuery(int id)
        {
            Id = id;
        }
    }
}
