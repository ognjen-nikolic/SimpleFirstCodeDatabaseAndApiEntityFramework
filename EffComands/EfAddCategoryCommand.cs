using Aplication.Commands;
using Aplication.Dto;
using Aplication.Exceptions;
using EFDATAACCES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EffComands
{
    public class EfAddCategoryCommand : BaseEfCommands, IAddCategoryCommand
    {
        public EfAddCategoryCommand(EfDbContext context) : base(context)
        {
        }

        public void Execute(CategoryDto request)
        {
            if (Context.Categories.Any(c => c.Name.ToLower() == request.Name.ToLower()))
            {
                throw new EntityAlreadyExistsException();
            }
            Context.Categories.Add(new Domain.Category
            {
                Name = request.Name,
                IsActive = true
                
            });
            Context.SaveChanges();
        }
    }
}
