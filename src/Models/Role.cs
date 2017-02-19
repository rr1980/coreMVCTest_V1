using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Role : IEntity
    {
        public int RoleId { get; set; }
        public UserRoleType UserRoleType { get; set; }

        public virtual ICollection<RoleToUser> RoleToUser { get; set; }
    }
}
