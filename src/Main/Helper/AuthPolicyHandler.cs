﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Common;
using Microsoft.AspNetCore.Authorization;

namespace Main.Helper
{
    public class AuthPolicyHandler : AuthorizationHandler<AuthPolicyRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AuthPolicyRequirement requirement)
        {
            var hasRole = context.User.Claims.Where(c => c.Type == ClaimTypes.Role).Any(f=>f.Value == requirement.UserRoleType.ToString());

            if (hasRole)
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }

            return Task.CompletedTask;
        }

        private UserRoleType _getEnum(Claim c)
        {
            return (UserRoleType)Enum.Parse(typeof(UserRoleType), c.Value);
        }

    }
}
