﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Model.Auth;
using Persistence.DatabaseContext;

namespace Auth.Service
{
    public class ApplicationRoleManager : RoleManager<IdentityRole>
    {
        public ApplicationRoleManager(IRoleStore<IdentityRole, string> roleStore)
        : base(roleStore) { }

        public static ApplicationRoleManager Create(
            IdentityFactoryOptions<ApplicationRoleManager> options,
            IOwinContext context)
        {
            var manager = new ApplicationRoleManager(
                new RoleStore<IdentityRole>(context.Get<ApplicationDbContext>()));
            return manager;
        }
    }
}
