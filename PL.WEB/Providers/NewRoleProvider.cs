using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;

namespace PL.WEB.Providers
{
    public class NewRoleProvider : RoleProvider
    {
        public IUserService userService
        {
            get
            {
                return (IUserService)DependencyResolver.Current.GetService(typeof(UserService));
            }
        }

        public IRoleService roleService
        {
            get
            {
                return (IRoleService)DependencyResolver.Current.GetService(typeof(RoleService));
            }
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            UserDTO user = userService.GetUserByEmail(username);
            
            if (user == null)
                return false;

            RoleDTO role = roleService.GetRole(user.RoleId);

            if (role != null && role.Name == roleName)
                return true;
            return false;
        }

        public override string[] GetRolesForUser(string username)
        {
            String[] role = null;
            var user = userService.GetUserByEmail(username);

            if (user == null)
                return role;

            var userRole = roleService.GetRole(user.RoleId);

            if (userRole != null)
                role = new String[] { userRole.Name };

            return role;
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}