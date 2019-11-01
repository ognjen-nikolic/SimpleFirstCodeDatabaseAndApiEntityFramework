using Aplication.Commands;
using Aplication.Dto;
using Aplication.Exceptions;
using Domain;
using EFDATAACCES;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EffComands
{
    public class EfUpdateProductCommand : BaseEfCommands, IUpdateProductCommand
    {
        public EfUpdateProductCommand(EfDbContext context) : base(context)
        {
        }

        public void Execute(ProductDto request)
        {
            var productCategories = new List<ProductCategory>();
            var product1 = Context.Products.Include(c => c.ProductCategories).ThenInclude(c => c.Category).Where(c => c.Id == request.Id).SingleOrDefault();
            if (product1== null)
                throw new EntityNotFoundException();
            if (Context.Products.Any(p => p.Name.ToLower() == request.Name.ToLower()))
                throw new EntityAlreadyExistsException();
            foreach(var item in request.CategoryNames)
            {
            var category= Context.Categories.SingleOrDefault(c => c.Name == item);
                if (category == null)
                    throw new EntityNotFoundException();
                productCategories.Add(new ProductCategory
                {
                    CategoryId = category.Id,
                    ProductId = product1.Id
                });
            }
            

            
          
            product1.Name = request.Name;
            product1.Description = request.Description;
            product1.Price = request.Price;
            product1.ProductCategories = productCategories;
            


            Context.SaveChanges();
        }
    }
}
