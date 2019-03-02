using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cars.Models;

namespace Cars.Classes
{
	/*class for pages on site*/
	public class Pages
	{
		public int namber { get; set; }
		public string activeName { get; set; }

		public Pages(int _namber, string _active)
		{
			this.namber = _namber;
			this.activeName = _active;
		}
	}
}
