using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Globalization;

namespace Cars.Models
{
	public class Comment
	{
		public string user { get; set; }
		public string message { get; set; }
		public string date { get; set; }

		public Comment():base(){}

		public Comment(string _usr, string _msg, DateTime _dt)
		{
			this.user = _usr;
			this.message = _msg;

			CultureInfo cult = new CultureInfo("en-Us");
			this.date = _dt.ToString("f", cult);
			
		}
	}

	public class CommentAndProduct
	{
		public string message { get; set; }
		public string namePost { get; set; }
		public string id { get; set; }

		public CommentAndProduct():base(){}

		public CommentAndProduct(string _msg, string _mk, string _md, string _cb, string _crt, string _id)
		{
			this.message = _msg;
			this.namePost = _mk + " " + _md + " " + _cb + ", " + _crt + "y.";
			this.id = _id;
		}
	}
}
