using Common;
using System.Collections.Generic;

namespace Models
{
    public class User : IEntity
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Vorname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public ICollection<Role> Roles { get; set; }
    }
}