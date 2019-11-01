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
    public class EfUpdateCategoryCommand : BaseEfCommands, IUpdateCategoryCommand
    {
        public EfUpdateCategoryCommand(EfDbContext context) : base(context)
        {
        }

        public void Execute(CategoryDto request)
        {
            var category = Context.Categories.Find(request.Id);
            if (category == null)
            {
                throw new EntityNotFoundException();
            }
           if(category.Name != request.Name)
            {
                if (Context.Categories.Any(c => c.Name.ToLower() == request.Name.ToLower()))
                {
                    throw new EntityAlreadyExistsException();
                }
                category.Name = request.Name;
                Context.SaveChanges();
            }
        }
    }
}
