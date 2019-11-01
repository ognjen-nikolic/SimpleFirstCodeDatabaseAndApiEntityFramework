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
    public class EfAddProductCommand : BaseEfCommands, IAddProductCommand
    {
        public EfAddProductCommand(EfDbContext context) : base(context)
        {
        }

        public void Execute(ProductDto request)
        {



            if (Context.Products.Any(p => p.Name.ToLower() == request.Name.ToLower()))
                throw new EntityAlreadyExistsException();
            foreach (var item in request.CategoryNames)
            {
                var category = Context.Categories.SingleOrDefault(p => p.Name.ToLower() == item.ToLower());
                if (category == null)
                {
                    throw new EntityNotFoundException();
                }
            }
                var addProduct = Context.Products.Add(new Domain.Product
                {
                    Name = request.Name,
                    Description = request.Description,
                    Price = request.Price,
                    IsActive=true


                });
                Context.SaveChanges();
                var product = Context.Products.Include(pc=>pc.ProductCategories).ThenInclude(c=>c.Category).SingleOrDefault(p => p.Name == request.Name);
                foreach (var item1 in request.CategoryNames)
                {
                    var category1 = Context.Categories.SingleOrDefault(p => p.Name.ToLower() == item1.ToLower());


                    product.ProductCategories.Add(new ProductCategory
                    {

                        CategoryId = category1.Id,
                        ProductId = product.Id

                    });

                }
                Context.SaveChanges();
            }
        }
    }

