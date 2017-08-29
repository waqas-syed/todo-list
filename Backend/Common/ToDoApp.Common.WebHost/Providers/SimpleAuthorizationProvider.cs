﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Owin.Security.OAuth;
using Ninject;
using ToDoApp.Identity.Persistence.Repositories;

namespace ToDoApp.Common.WebHost.Providers
{
    /// <summary>
    /// Authorization Server provider
    /// </summary>
    public class SimpleAuthorizationProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var accountRepository = 
                (IAccountRepository)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IAccountRepository));
            var user = accountRepository.GetUserByPassword(context.UserName, context.Password);
            if (user == null)
            {
                context.SetError("Invalid_grant", "Email or password is incorrect");
                return;
            }
            var claims = new ClaimsIdentity(context.Options.AuthenticationType);
            claims.AddClaim(new Claim("sub", context.UserName));
            claims.AddClaim(new Claim("role", "user"));

            context.Validated(claims);
        }
    }
}