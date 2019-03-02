using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace Cars.Models
{
	public class ProductInfo
	{
		public int id { get; set; }

		[Required]
		[Display(Name = "Maker: ")]
		[MaxLength(30,ErrorMessage = "Length maker < 30")]
		public string maker { get; set; }

		[Required]
		[Display(Name = "Model: ")]
		[MaxLength(30, ErrorMessage = "Length model < 30")]
		public string model { get; set; }

		[Required]
		[Display(Name = "Year creation: ")]
		public Int16 yearCreation { get; set; }

		[Required]
		[Display(Name = "Price: ")]
		public int price { get; set; }

		public int day { get; set; }
		public string month { get; set; }
		public int year { get; set; }

		[Required]
		public string image { get; set; }

		[Required]
		[Display(Name = "Type engine: ")]
		[MaxLength(15, ErrorMessage = "Length type engine < 15")]
		public string typeEngine { get; set; }

		[Required]
		[Display(Name = "Engine capacity: ")]
		public Int16 vEngine { get; set; }

		[Required]
		[Display(Name = "Chassis: ")]
		[MaxLength(10, ErrorMessage = "Length chassis < 15")]
		public string chassis { get; set; }

		[Required]
		[Display(Name = "Type cabin: ")]
		[MaxLength(30, ErrorMessage = "Length type cabin < 30")]
		public string typeCabin { get; set; }

		[Required]
		[Display(Name = "Horse power: ")]
		public Int16 horsePower { get; set; }

		[Required]
		[Display(Name = "Color: ")]
		[MaxLength(50, ErrorMessage = "Length color < 30")]
		public string color { get; set; }

		[Required]
		[Display(Name = "Type car: ")]
		public string typeCars { get; set; }

		[Display(Name = "Power: ")]
		public Int16 power { get; set; }

		[Required]
		[Display(Name = "Max torque: ")]
		public Int16 maxKM { get; set; }

		[Required]
		[Display(Name = "Max power at a: ")]
		[MaxLength(10, ErrorMessage = "Length max power < 10(xxxx-xxxx)")]
		public string maxPowerKM { get; set; }

		[Required]
		[Display(Name = "Max torque at")]
		[MaxLength(10, ErrorMessage = "Length max torque < 10(xxxx-xxxx)")]
		public string maxKMRevolution { get; set; }

		[Required]
		[Display(Name = "Type transmission: ")]
		public string typeTransmission { get; set; }

		[Required]
		[Display(Name = "Number of gears: ")]
		public Int16 countTransmission { get; set; }

		[Required]
		[Display(Name = "Type fuel: ")]
		public string typeFuel { get; set; }

		public ProductInfo()
		{
			this.id = 0;
			this.maker = "";
			this.model = "";
			this.yearCreation = 0;
			this.price = 0;
			this.day = 0;
			this.month = "";
			this.year = 0;
			this.image = "";
			this.typeEngine = "";
			this.vEngine = 0;
			this.chassis = "";
			this.typeCabin = "";
			this.horsePower = 0;
			this.color = "";
			this.typeCars = "";
			this.power = 0;
			this.maxKM = 0;
			this.maxPowerKM = "";
			this.maxKMRevolution = "";
			this.typeTransmission = "";
			this.countTransmission = 0;
			this.typeFuel = "";
		}

		public ProductInfo(int _id, string _maker, string _model, Int16 _yearCreation, int _price, int _day, 
			string _month, int _year, string _image, string _typeEngine, Int16 _vEngine, string _chassis, 
			string _typeCabin, Int16 _horsePower, string _color, string _typeCars, Int16 _power, 
			Int16 _maxKM, string _maxPowerKM, string _maxKMRevolution, string _typeTrans, Int16 _countTrans,
			string _typeFuel)
		{
			this.id = _id;
			this.maker = _maker;
			this.model = _model;
			this.yearCreation = _yearCreation;
			this.price = _price;
			this.day = _day;
			this.month = _month;
			this.image = "../BD/" + _image;
			this.typeEngine = _typeEngine;
			this.vEngine = _vEngine;
			this.chassis = _chassis;
			this.typeCabin = _typeCabin;
			this.year = _year;
			this.horsePower = _horsePower;
			this.color = _color;
			this.typeCars = _typeCars;
			this.power = _power;
			this.maxKM = _maxKM;
			this.maxPowerKM = _maxPowerKM;
			this.maxKMRevolution = _maxKMRevolution;
			this.typeTransmission = _typeTrans;
			this.countTransmission = _countTrans;
			this.typeFuel = _typeFuel;
		}


		public override bool Equals(object obj)
		{
			if (obj == null) return false;
			if (this.id == ((ProductInfo) obj).id)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public void AddDate(DateTime time)
		{
			this.day = time.Day;
			this.month = time.Month.ToString("MM");
			this.year = time.Year;
		}
	}

	public class ProductInfoView:ProductInfo
	{
		public List<SelectListItem> makers = new List<SelectListItem>();
 		public List<SelectListItem> models = new List<SelectListItem>();
 		public List<SelectListItem> typeCars = new List<SelectListItem>();
 		public List<SelectListItem> typeFuels = new List<SelectListItem>();
		public List<SelectListItem> typeTransmissions = new List<SelectListItem>();

		public void InitSelectView(SqlConnection _connect)
		{
			this.makers = this.InitList(_connect, "select distinct maker from Product ", "order by maker");
			this.models = this.InitModelsList(_connect);
			this.typeCars = this.InitList(_connect, "select distinct Type_car from Product ", "order by Type_car");
			this.typeFuels = this.InitList(_connect, "select distinct Type_fuel from Product ", "order by Type_fuel");
			this.typeTransmissions = this.InitTypeTransmissionList(_connect);
		}

		public List<SelectListItem> InitList(SqlConnection _connect, string sql, string order)
		{

			string sqlQuery = sql + order;
			List<SelectListItem> list = new List<SelectListItem>();

			_connect.Open();

			SqlCommand cmd = new SqlCommand(sql,_connect);
			SqlDataReader reader = cmd.ExecuteReader();

			while (reader.HasRows)
			{
				while (reader.Read())
				{
					list.Add(new SelectListItem {Text = reader.GetString(0), Value = reader.GetString(0)});
				}
				reader.NextResult();
			}

			reader.Close();
			_connect.Close();

			return list;
		}
		
		public List<SelectListItem> InitModelsList(SqlConnection _connect)
		{
			return new List<SelectListItem>();
		}

		public List<SelectListItem> InitTypeTransmissionList(SqlConnection _connect)
		{
			List<SelectListItem> list = new List<SelectListItem>();
			list.Add(new SelectListItem{Text = "Automatic", Value = "1"});
			list.Add(new SelectListItem{Text = "Mechanical", Value = "0"});
			return list;
		} 

	}

	public class ItemGroup
	{
		public List<SelectListItem> maker = new List<SelectListItem>(); 
		public List<SelectListItem> model = new List<SelectListItem>();
		public List<SelectListItem> typeFuel = new List<SelectListItem>();

		public void GetData(SqlConnection _connect)
		{
			string sqlQuery = "Select distinct Maker from Product";

			_connect.Open();
			SqlCommand sql = new SqlCommand(sqlQuery, _connect);

			SqlDataReader reader = sql.ExecuteReader();
			while (reader.HasRows)
			{
				while (reader.Read())
				{
					this.maker.Add(new SelectListItem{Value = reader.GetString(0), Text = reader.GetString(0)});
				}
				reader.NextResult();
			}
			reader.Close();


			sqlQuery = "Select distinct Type_fuel from Product";

			sql = new SqlCommand(sqlQuery, _connect);
			reader = sql.ExecuteReader();
			while (reader.HasRows)
			{
				while (reader.Read())
				{
					this.typeFuel.Add(new SelectListItem { Value = reader.GetString(0), Text = reader.GetString(0) });
				}
				reader.NextResult();
			}
			reader.Close();
			_connect.Close();
		}
	}
}
