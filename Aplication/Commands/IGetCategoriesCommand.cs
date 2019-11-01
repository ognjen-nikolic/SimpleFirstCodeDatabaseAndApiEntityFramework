using Aplication.Dto;
using Aplication.Interfaces;
using Aplication.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Commands
{
    public interface IGetCategoriesCommand : ICommands<CategoriesSearch, IEnumerable<CategoryDto>>
    {
    }
   
}
