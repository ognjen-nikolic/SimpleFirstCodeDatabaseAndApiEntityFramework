using Aplication.Commands;
using Aplication.Dto;
using Aplication.Exceptions;
using EFDATAACCES;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EffComands
{
    public class EfGetProductCommand : BaseEfCommands, IGetProductCommand
    {
        public EfGetProductCommand(EfDbContext context) : base(context)
        {
        }

        public ProductDto Execute(int request)
        {



            var product = Context.Products.Include(cp=>cp.ProductCategories).ThenInclude(c=>c.Category).SingleOrDefault(p=>p.Id==request);
            
           
            
            if (product == null)
                throw new EntityNotFoundException();
         
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CategoryNames=product.ProductCategories.Select(c=>c.Category.Name).ToList()
             
               
            };
            
            
        }
       
    }
}
