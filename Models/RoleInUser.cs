using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Cars.Models;

namespace Cars.Models
{
	public class RoleInUser:User
	{
		public List<Role> roles;

		public RoleInUser() : base()
		{
			roles = new List<Role>();
		}

		public void GetRoles()
		{
			this.roles.Clear();
			string[] rol = Roles.GetRolesForUser(this.nickName);

			foreach (string chr in rol)
			{
				this.roles.Add(new Role(chr));
			}
		}

		public void AddUser(User user)
		{
			this.nickName = user.nickName;
			this.firstName = user.firstName;
			this.lastName = user.lastName;
			this.address = user.address;
			this.email = user.email;
			this.password = user.password;
			this.phone = user.phone;
			this.image = user.image;
		}
	}
}