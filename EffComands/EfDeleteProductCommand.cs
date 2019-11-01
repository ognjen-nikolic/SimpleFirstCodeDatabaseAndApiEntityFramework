using Aplication.Commands;
using Aplication.Exceptions;
using EFDATAACCES;
using System;
using System.Collections.Generic;
using System.Text;

namespace EffComands
{
    public class EfDeleteProductCommand : BaseEfCommands, IDeleteProductCommand
    {
        public EfDeleteProductCommand(EfDbContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var product = Context.Products.Find(request);
            if (product == null)
                throw new EntityNotFoundException();
            Context.Remove(product);
            Context.SaveChanges();
        }
    }
}
