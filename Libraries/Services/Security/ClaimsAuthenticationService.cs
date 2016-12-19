﻿using Services.Users;
using System;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Infrastructure;
using Microsoft.Owin.Security;
using Core.Domain;

namespace Services.Security
{
    public class ClaimsAuthenticationService : IAuthenticationService
    {
        #region Fields

        private readonly UserService _userService;

        private User _cachedUser;

        private readonly IAuthenticationManager _authenticationManager;

        #endregion

        #region Ctor

        public ClaimsAuthenticationService(UserService userService, IAuthenticationManager authenticationManager)
        {
            _userService = userService;
            _authenticationManager = authenticationManager;
        }

        #endregion

        #region Methods

        public void SignIn(User user, bool createPersistentCookie)
        {
            var applicationIdentity = new ClaimsIdentity(DefaultAuthenticationTypes.ApplicationCookie);
            applicationIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Code));
            applicationIdentity.AddClaim(new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "ASP.NET Identity"));

            // Cookie
            var authProerties = new AuthenticationProperties { IsPersistent = createPersistentCookie };
            if (authProerties.IsPersistent)
            {
                var currentUtc = new SystemClock().UtcNow;
                authProerties.IssuedUtc = currentUtc;
                authProerties.ExpiresUtc = currentUtc.Add(TimeSpan.FromDays(30));
            }
            _authenticationManager.SignIn(authProerties, applicationIdentity);
            _cachedUser = user;
        }

        public void SignOut()
        {
            _cachedUser = null;
            _authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }

        public User GetAuthenticatedUser()
        {
            if (_cachedUser != null)
            {
                return _cachedUser;
            }

            if (!(_authenticationManager?.User.Identity is ClaimsIdentity))
            {
                return null;
            }

            var formsIdentity = (ClaimsIdentity)_authenticationManager.User.Identity;
            //User user = GetAuthenticatedUserFromClaims(formsIdentity);
            //if (user != null)
            //{
            //    _cachedUser = user;
            //}

            return _cachedUser;
        }

        //public virtual User GetAuthenticatedUserFromClaims(ClaimsIdentity identity)
        //{
        //    if (identity == null)
        //    {
        //        throw new ArgumentNullException(nameof(identity));
        //    }

        //    string code = identity.FindFirstValue(ClaimTypes.NameIdentifier);

        //    if (String.IsNullOrWhiteSpace(code))
        //    {
        //        return null;
        //    }
        //    var user = _userService.GetByCode(code);
        //    return user;
        //}

        #endregion
    }
}