using Aplication.Commands;
using Aplication.Dto;
using Aplication.Exceptions;
using EFDATAACCES;
using System;
using System.Collections.Generic;
using System.Text;

namespace EffComands
{
    public class EfGetCategoryCommand : BaseEfCommands, IGetCategoryCommand
    {
        public EfGetCategoryCommand(EfDbContext context) : base(context)
        {
        }

        public CategoryDto Execute(int request)
        {
            var category = Context.Categories.Find(request);
            
            if (category == null)
                throw new EntityNotFoundException();
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name

            };
        }
    }
}
