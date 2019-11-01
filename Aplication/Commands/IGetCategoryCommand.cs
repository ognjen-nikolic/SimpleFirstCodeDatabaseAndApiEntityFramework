using Aplication.Dto;
using Aplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Commands
{
    public interface IGetCategoryCommand : ICommands<int, CategoryDto>
    {

    }
    
}
