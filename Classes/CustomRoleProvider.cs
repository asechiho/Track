using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Data.SqlClient;

namespace Cars.Classes
{
	public class CustomRoleProvider:RoleProvider
	{
		SqlConnection connect = new SqlConnection("Data Source=(local); Initial Catalog=CARS; Integrated Security=SSPI;");

		/*get all roles for user*/
		public override string[] GetRolesForUser(string username)
		{
			int userId = ReadSqlServer.ReadIdUser(connect, username);

			string[] roles = ReadSqlServer.ReadRolesInUser(connect, userId);

			return roles;
		}

		/*creating new role*/
		public override void CreateRole(string roleName)
		{
			string sql = "insert into Roles(Name) values('" + roleName + "')";

			WriteSqlServer.UpdateDBonQuery(connect, sql);
		}

		/*user belongs to the specified role*/
		public override bool IsUserInRole(string username, string roleName)
		{
			int userId = ReadSqlServer.ReadIdUser(connect, username);

			string role = ReadSqlServer.ReadRoleInUser(connect, userId, roleName);
			if (role == roleName)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public override void AddUsersToRoles(string[] usernames, string[] roleNames)
		{
			throw new NotImplementedException();
		}

		public override string ApplicationName { get; set; }

		public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
		{
			throw new NotImplementedException();
		}

		public override string Description
		{
			get { return base.Description; }
		}

		public override string[] FindUsersInRole(string roleName, string usernameToMatch)
		{
			throw new NotImplementedException();
		}

		public override string[] GetUsersInRole(string roleName)
		{
			throw new NotImplementedException();
		}

		public override bool RoleExists(string roleName)
		{
			throw new NotImplementedException();
		}

		public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
		{
			throw new NotImplementedException();
		}

		public override string[] GetAllRoles()
		{
			throw new NotImplementedException();
		}
	}
}