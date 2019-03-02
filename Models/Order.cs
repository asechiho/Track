using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cars.Models
{
	public class Order
	{
		public int id_product { get; set; }
		public int id_user { get; set; }
		public string addr { get; set; }
		public string phone { get; set; }
		public DateTime date { get; set; }

		private sbyte stat { get; set; }

		public void Stat_Null()
		{
			this.stat = 0;
		}

		public void Create_Date()
		{
			date = DateTime.Now;
		}

		public int Stat()
		{
			return this.stat;
		}
		/*Constructor*/
		public Order():base(){}

		public Order(int _id_pr, int _id_us, string _adr, string _ph)
		{
			this.id_user = _id_us;
			this.id_product = _id_pr;
			this.phone = _ph;
			this.addr = _adr;
			this.Stat_Null();
			this.Create_Date();
		}
	}
}
