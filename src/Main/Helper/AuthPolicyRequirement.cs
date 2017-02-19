using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Microsoft.AspNetCore.Authorization;

namespace Main.Helper
{
    public class AuthPolicyRequirement : IAuthorizationRequirement
    {
        public UserRoleType UserRoleType;


        public AuthPolicyRequirement(UserRoleType type)
        {
            this.UserRoleType = type;
        }
    }
}
