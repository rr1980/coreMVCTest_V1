using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class RoleToUser
    {
        public int RoleToUserId { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }
    }

    public class Role : IEntity
    {
        public Role()
        {

        }
        public Role(string bezeichnung)
        {
            this.Bezeichnung = bezeichnung;
        }

        public int RoleId { get; set; }
        public string Bezeichnung { get; set; }

            //public ICollection<Role> Roles { get; set; }
        //public int UserId { get; set; }
        //public User User { get; set; }
    }
}
