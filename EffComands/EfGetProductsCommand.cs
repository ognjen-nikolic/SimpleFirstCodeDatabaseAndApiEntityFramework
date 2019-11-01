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
    public class EfGetProductsCommand : BaseEfCommands, IGetProductsCommand
    {
        public EfGetProductsCommand(EfDbContext context) : base(context)
        {
        }

        public IEnumerable<ProductDto> Execute(ProductSearch request)
        {
            var query = Context.Products.AsQueryable();
            if (request.MinPrice != null)
              query= query.Where(p => p.Price >= request.MinPrice);
            if (request.MaxPrice != null)
                query = query.Where(p => p.Price <= request.MaxPrice);
            if (request.ProductName != null)
                query = query.Where(p => p.Name.ToLower().Contains(request.ProductName.ToLower()));
            query = query.Where(p => p.IsActive == true);
           return query.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Description = p.Description,
                CategoryNames = p.ProductCategories.Select(pc => pc.Category.Name)
            });
            
                
        }
    }
}
