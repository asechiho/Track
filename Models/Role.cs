using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Cars.Classes;

namespace Cars.Models
{
	public class Role
	{
		[Required]
		[Display(Name = "Role name: ")]
		[MaxLength(10, ErrorMessage = "length role name < 10")]
		public string name { get; set; }

		public Role()
		{
			this.name = "";
		}

		public bool AddNewRole(SqlConnection connect)
		{
			string sql = "insert into Role(Name) values('" + this.name + "')";

			return WriteSqlServer.UpdateDBonQuery(connect, sql);

		}
	}
}