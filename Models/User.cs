using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Cars.Models
{
	public class User
	{
		[Required]
		[Display(Name = "First Name")]
		[MaxLength(20, ErrorMessage = "Maxlength < 21")]
		public string firstName { get; set; }

		[Required]
		[Display(Name = "Last Name")]
		[MaxLength(30, ErrorMessage = "Maxlength < 31")]
		public string lastName { get; set; }

		[Required]
		[Display(Name = "Nick Name")]
		[MaxLength(30, ErrorMessage = "Maxlength < 31")]
		public string nickName { get; set; }

		[Required]
		[Display(Name = "Email")]
		[MaxLength(128, ErrorMessage = "Maxlength < 128")]
		public string email { get; set; }

		[Required]
		[Display(Name = "Phone")]
		[MaxLength(9, ErrorMessage = "Maxlength < 10")]
		public string phone { get; set; }

		[Display(Name = "Address")]
		[MaxLength(256, ErrorMessage = "Maxlength < 256")]
		public string address { get; set; }

		[Required]
		[Display(Name = "Password")]
		[DataType(DataType.Password)]
		[MaxLength(25, ErrorMessage = "Maxlength < 25")]
		public string password { get; set; }

		public string image { get; set; }
		
		public string id { get; set; }

		[Required]
		[Display(Name = "RememberMe")]
		public bool remember { get; set; }
	}
}
