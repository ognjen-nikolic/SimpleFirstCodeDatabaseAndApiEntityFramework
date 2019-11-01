using EFDATAACCES;
using System;
using System.Collections.Generic;
using System.Text;

namespace EffComands
{
    public abstract class BaseEfCommands
    {
      

        protected EfDbContext Context {get;}

        protected BaseEfCommands(EfDbContext context)
        {
            Context = context;
        }
    }
}
