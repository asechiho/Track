using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cars.Models
{
	public class UserVIewLogin
	{
		[Required]
		[Display(Name = "Nick Name")]
		[MaxLength(30, ErrorMessage = "Maxlength < 31")]
		public string nickName { get; set; }

		[Required]
		[Display(Name = "Password")]
		[DataType(DataType.Password)]
		[MaxLength(25, ErrorMessage = "Maxlength < 25")]
		public string password { get; set; }

		[Required]
		[Display(Name = "RememberMe")]
		public bool remember { get; set; }
	}
}