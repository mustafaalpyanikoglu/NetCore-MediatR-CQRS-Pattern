using MediatR;
using Web_API.Models;

namespace Web_API.Data.Commands
{
    public class CreateCategoryCommand:IRequest<Category>
    {
        public Category Category { get; set; }

        public CreateCategoryCommand(Category category)
        {
            this.Category = category;
        }
    }
}
