using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class User:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
