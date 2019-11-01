using Aplication.Commands;
using Aplication.Dto;
using Aplication.Searches;
using EFDATAACCES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EffComands
{
    public class EfGetCategoriesCommand : BaseEfCommands, IGetCategoriesCommand
    {
        public EfGetCategoriesCommand(EfDbContext context) : base(context)
        {
        }

        public IEnumerable<CategoryDto> Execute(CategoriesSearch request)
        {
            var categories = Context.Categories.AsQueryable();
            if (request.Name != null)
                categories = categories.Where(c => c.Name.ToLower().Contains(request.Name.ToLower()));
            if (request.OnlyActive != null)
                categories = categories.Where(c => c.IsActive == request.OnlyActive);
            if (request.OnlyActive == null)
                categories = categories.Where(c => c.IsActive);
            return categories.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name

            });



        }
    }
}
