using Aplication.Commands;
using Aplication.Exceptions;
using EFDATAACCES;
using System;
using System.Collections.Generic;
using System.Text;

namespace EffComands
{
    public class EfDeleteCategoryCommand : BaseEfCommands, IDeleteCategoryCommand
    {
        public EfDeleteCategoryCommand(EfDbContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var category = Context.Categories.Find(request);
            if (category == null)
            {
                throw new EntityNotFoundException();
            }
            Context.Remove(category);
            Context.SaveChanges();
        }
    }
}
