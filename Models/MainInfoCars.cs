using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cars.Models
{
	public class MainInfoCars
	{
		public int id { get; set; }
		public string maker { get; set; }
		public string model { get; set; }
		public Int16 yearCreation { get; set; }
		public int price { get; set; }
		public int day { get; set; }
		public string month { get; set; }
		public string image { get; set; }
		public string typeEngine { get; set; }
		public Int16 vEngine { get; set; }
		public string chassis { get; set; }
		public string typeCabin { get; set; }

		public MainInfoCars()
		{
			this.id = 0;
			this.maker = "";
			this.model = "";
			this.yearCreation = 0;
			this.price = 0;
			this.day = 0;
			this.month = "";
		}

		public MainInfoCars(int _id, string _maker, string _model, Int16 _year, int _price, int _day, 
			string _month, string _image, string _typeEngine, Int16 _vEngine, string _chassis, string _typeCabin)
		{
			this.id = _id;
			this.maker = _maker;
			this.model = _model;
			this.yearCreation = _year;
			this.price = _price;
			this.day = _day;
			this.month = _month;
			this.image = "../BD/" + _image;
			this.typeEngine = _typeEngine;
			this.vEngine = _vEngine;
			this.chassis = _chassis;
			this.typeCabin = _typeCabin;
		}

		public override bool Equals(object obj)
		{
			if(obj == null) return false;
			if (this.id == ((MainInfoCars) obj).id) return true;
			else return false;
		}
	}
}