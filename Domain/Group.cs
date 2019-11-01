using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Group:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
