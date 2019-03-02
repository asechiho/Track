using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using Cars.Models;

namespace Cars.Classes
{
	public static class ReadSqlServer
	{
		public static List<MainInfoCars> ReadMainInfoCarses(SqlConnection _connect) 
		{
			List<MainInfoCars> carses = new List<MainInfoCars>();

			string _sqlQuery =
				"select TOP 5 id, Maker, Model, Year_creation, Price, DAY(Date_add), DATENAME(MONTH, Date_add), Image, Engine, V_engine, Chassis, Cabin from Product order by Date_add desc";
			
			_connect.Open();
			SqlCommand sql = new SqlCommand(_sqlQuery, _connect);

			SqlDataReader reader = sql.ExecuteReader();

			while (reader.HasRows)
			{
				while (reader.Read())
				{
					carses.Add(new MainInfoCars(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
						reader.GetInt16(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetString(6),
						reader.GetString(7), reader.GetString(8), reader.GetInt16(9), reader.GetString(10),
						reader.GetString(11)));
				}
				reader.NextResult();
			}
			reader.Close();
			_connect.Close();
			
			return carses;
		}

		public static List<ProductInfo> ReadProductInfos(SqlConnection _connect,string _sql, int _count)
		{
			List<ProductInfo> carses = new List<ProductInfo>();

			int i  = 0;
			string sqlQuery =
				"select id, Maker, Model, Year_creation, Price, " +
				"DAY(Date_add), DATENAME(MONTH,Date_add),YEAR(Date_add), " +
				"Image, Engine, V_engine, Chassis, Cabin, Horse_power, Color,Type_car, " +
				"Power, Max_KM, Max_power_KM, Max_KM_revolution, Type_transmission, " +
				"Count_transmission, Type_fuel from Product";

			sqlQuery += " " + _sql;
			_connect.Open();
			SqlCommand sql = new SqlCommand(sqlQuery, _connect);

			SqlDataReader reader = sql.ExecuteReader();

			while (reader.HasRows)
			{
				while (reader.Read())
				{
					if (i > _count*6-1 && i < _count*6 + 6)
					{
						carses.Add(new ProductInfo(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
							reader.GetInt16(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetString(6),
							reader.GetInt32(7), reader.GetString(8), reader.GetString(9), reader.GetInt16(10),
							reader.GetString(11), reader.GetString(12), reader.GetInt16(13), reader.GetString(14),
							reader.GetString(15), reader.GetInt16(16), reader.GetInt16(17), reader.GetString(18),
							reader.GetString(19), reader.GetString(20), reader.GetInt16(21), reader.GetString(22)));
					}
					i++;
				}
				reader.NextResult();
			}
			reader.Close();
			_connect.Close();

			return carses;
		}

		public static List<ProductInfo> ReadProductInfos(SqlConnection _connect, string _sql)
		{
			List<ProductInfo> carses = new List<ProductInfo>();

			string sqlQuery =
				"select Top 6 id, Maker, Model, Year_creation, Price, " +
				"DAY(Date_add), DATENAME(MONTH,Date_add),YEAR(Date_add), " +
				"Image, Engine, V_engine, Chassis, Cabin, Horse_power, Color,Type_car, " +
				"Power, Max_KM, Max_power_KM, Max_KM_revolution, Type_transmission, " +
				"Count_transmission, Type_fuel from Product";

			sqlQuery += " " + _sql;

			_connect.Open();
			SqlCommand sql = new SqlCommand(sqlQuery, _connect);

			SqlDataReader reader = sql.ExecuteReader();

			while (reader.HasRows)
			{
				while (reader.Read())
				{
					carses.Add(new ProductInfo(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
						reader.GetInt16(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetString(6),
						reader.GetInt32(7), reader.GetString(8), reader.GetString(9), reader.GetInt16(10),
						reader.GetString(11), reader.GetString(12), reader.GetInt16(13), reader.GetString(14),
						reader.GetString(15), reader.GetInt16(16), reader.GetInt16(17), reader.GetString(18),
						reader.GetString(19), reader.GetString(20), reader.GetInt16(21), reader.GetString(22)));
				}
				reader.NextResult();
			}
			reader.Close();
			_connect.Close();

			return carses;
		}

		public static int ReadCountProduct(SqlConnection _connect, string _sql)
		{
			string sqlQuery = "Select COUNT(*) from Product";

			sqlQuery += " " + _sql;

			_connect.Open();
			SqlCommand sql = new SqlCommand(sqlQuery, _connect);

			SqlDataReader reader = sql.ExecuteReader();

			int result = 0;
			while (reader.HasRows)
			{
				while (reader.Read())
				{
					result = reader.GetInt32(0);
				}
				reader.NextResult();
			}
			reader.Close();
			_connect.Close();
			return result;
		}

		public static List<SelectListItem> ReadModels(SqlConnection _connect, string _maker)
		{
			string sqlQuery = "Select distinct Model from Product where Maker = '" + _maker + "'";

			_connect.Open();
			SqlCommand sql = new SqlCommand(sqlQuery, _connect);

			SqlDataReader reader = sql.ExecuteReader();

			List<SelectListItem> result = new List<SelectListItem>();
			while (reader.HasRows)
			{
				while (reader.Read())
				{
					result.Add(new SelectListItem{Value = reader.GetString(0), Text = reader.GetString(0)});
				}
				reader.NextResult();
			}
			reader.Close();
			_connect.Close();
			return result;
		}

		public static List<string> ReadMakers(SqlConnection _connect)
		{
			string sqlQuery = "Select distinct Maker from Product";

			_connect.Open();
			SqlCommand sql = new SqlCommand(sqlQuery, _connect);

			SqlDataReader reader = sql.ExecuteReader();

			List<string> result = new List<string>();
			while (reader.HasRows)
			{
				while (reader.Read())
				{
					result.Add(reader.GetString(0));
				}
				reader.NextResult();
			}
			reader.Close();
			_connect.Close();
			return result;
		}

		public static ProductInfo ReadProductId(SqlConnection _connect, int? _id)
		{
			ProductInfo carses = new ProductInfo();

			string sqlQuery =
				"select id, Maker, Model, Year_creation, Price, " +
				"DAY(Date_add), DATENAME(MONTH,Date_add),YEAR(Date_add), " +
				"Image, Engine, V_engine, Chassis, Cabin, Horse_power, Color,Type_car, " +
				"Power, Max_KM, Max_power_KM, Max_KM_revolution, Type_transmission, " +
				"Count_transmission, Type_fuel from Product where id = " + _id;

			_connect.Open();
			SqlCommand sql = new SqlCommand(sqlQuery, _connect);

			SqlDataReader reader = sql.ExecuteReader();

			while (reader.HasRows)
			{
				while (reader.Read())
				{
					carses = new ProductInfo(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
						reader.GetInt16(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetString(6),
						reader.GetInt32(7), reader.GetString(8), reader.GetString(9), reader.GetInt16(10),
						reader.GetString(11), reader.GetString(12), reader.GetInt16(13), reader.GetString(14),
						reader.GetString(15), reader.GetInt16(16), reader.GetInt16(17), reader.GetString(18),
						reader.GetString(19), reader.GetString(20), reader.GetInt16(21), reader.GetString(22));
				}
				reader.NextResult();
			}
			reader.Close();
			_connect.Close();

			return carses;
		}

		public static User ReadUser(SqlConnection _connect, string nick)
		{
			User user = new User();

			string sqlQuery =
				"select Nick_name, First_name, Last_name, Phone, Address, Email, Image, id_user from Users where Nick_name = '" + nick + "'";
			_connect.Open();
			SqlCommand sql = new SqlCommand(sqlQuery, _connect);

			SqlDataReader reader = sql.ExecuteReader();

			if (reader.HasRows)
			{
				while (reader.Read())
				{
					user.nickName = reader.GetString(0).Replace(" ", "");
					user.firstName = reader.GetString(1).Replace(" ", "");
					user.lastName = reader.GetString(2).Replace(" ", "");
					user.phone = reader.GetString(3).Replace(" ", "");
					user.address = reader.GetString(4).Replace(" ", "");
					user.email = reader.GetString(5).Replace(" ", "");
					user.image = reader.GetString(6).Replace(" ", "");
					user.id = reader.GetInt32(7).ToString();
				}
				reader.NextResult();
			}
			reader.Close();
			_connect.Close();

			return user;
		}

		public static UserViewEdit ReadUserV(SqlConnection _connect, string nick)
		{
			UserViewEdit user = new UserViewEdit();

			string sqlQuery =
				"select Nick_name, First_name, Last_name, Phone, Address, Email, Image, id_user from Users where Nick_name = '" + nick + "'";
			_connect.Open();
			SqlCommand sql = new SqlCommand(sqlQuery, _connect);

			SqlDataReader reader = sql.ExecuteReader();

			if (reader.HasRows)
			{
				while (reader.Read())
				{
					user.nickName = reader.GetString(0).Replace(" ", "");
					user.firstName = reader.GetString(1).Replace(" ", "");
					user.lastName = reader.GetString(2).Replace(" ", "");
					user.phone = reader.GetString(3).Replace(" ", "");
					user.address = reader.GetString(4).Replace(" ", "");
					user.email = reader.GetString(5).Replace(" ", "");
					user.image = reader.GetString(6).Replace(" ", "");
					user.id = reader.GetInt32(7).ToString();
				}
				reader.NextResult();
			}
			reader.Close();
			_connect.Close();

			return user;
		}

		public static int ReadIdUser(SqlConnection _connect, string nick)
		{
			int id = 1;

			string sqlQuery =
				"select id_user from Users where Nick_name = '" + nick + "'";
			_connect.Open();
			SqlCommand sql = new SqlCommand(sqlQuery, _connect);

			SqlDataReader reader = sql.ExecuteReader();

			if (reader.HasRows)
			{
				if (reader.Read())
				{
					id = reader.GetInt32(0);
				}
				reader.NextResult();
			}
			reader.Close();
			_connect.Close();

			return id;
		}

		public static List<BasketProduct> ReadBasketProducts(SqlConnection _connect, string listid)
		{
			List<BasketProduct> carses = new List<BasketProduct>();

			string sqlQuery =
				"select id, Maker, Model, Year_creation, Price, Image, Engine, V_engine, Cabin from Product where id  in(" + listid +
				")";

			_connect.Open();
			SqlCommand sql = new SqlCommand(sqlQuery, _connect);

			SqlDataReader reader = sql.ExecuteReader();

			while (reader.HasRows)
			{
				while (reader.Read())
				{
					BasketProduct cars = new BasketProduct();
					cars.id = reader.GetInt32(0);
					cars.image = reader.GetString(5);
					cars.mainInfo = reader.GetString(1) + " " + reader.GetString(2) + " " + reader.GetInt16(3) + "y.";
					cars.moreInfo = reader.GetString(6) + " " + reader.GetInt16(7) + "cm^3 " + reader.GetString(8);
					cars.price = reader.GetInt32(4);
					carses.Add(cars);
				}
				reader.NextResult();
			}
			reader.Close();
			_connect.Close();

			return carses;
		}

		public static int GetIdItem(SqlConnection _connect, string _sql)
		{
			_connect.Open();
			SqlCommand sql = new SqlCommand(_sql, _connect);

			SqlDataReader reader = sql.ExecuteReader();

			int result = 0;
			if (reader.HasRows)
			{
				if (reader.Read())
				{
					result = reader.GetInt32(0);
				}
				reader.NextResult();
			}
			reader.Close();
			_connect.Close();
			return result;
		}

		public static string GetIdBaketUser(SqlConnection _connect, int id)
		{
			string result = "", noresult="";
			DateTime current = new DateTime();
			current = DateTime.Now;
			DateTime oute = new DateTime();
			string sql = "Select Product_id, time_create, time_out from Basket where User_id = '" + id + "'";

			_connect.Open();
			SqlCommand cmd = new SqlCommand(sql, _connect);

			SqlDataReader reader = cmd.ExecuteReader();

			while (reader.HasRows)
			{
				while (reader.Read())
				{
					oute = reader.GetDateTime(2);
					if (current < oute)
					{
						result += Convert.ToString(reader.GetInt32(0));
						result += ",";
					}
					else
					{
						noresult += reader.GetInt32(0) + ", ";
					}
				}
				reader.NextResult();
			}
			reader.Close();
			_connect.Close();

			string[] str = noresult.Split(',');

			foreach (string one in str)
			{
				if (one != "")
				{
					WriteSqlServer.UpdateDBonQuery(_connect, "delete from Basket where User_id = " + id + " And Product_id = " + one);
				}
			}


			if (result == "")
			{
				return result;
			}
			return result.Remove(result.Length-1,1);
		}

		public static int GetCountItemBasket(SqlConnection _connect, int id)
		{
			int result = 0;
			string sql = "Select COUNT(*) from Basket where User_id = '" + id + "'";

			_connect.Open();
			SqlCommand cmd = new SqlCommand(sql, _connect);

			SqlDataReader reader = cmd.ExecuteReader();

			while (reader.HasRows)
			{
				while (reader.Read())
				{
					result = reader.GetInt32(0);
				}
				reader.NextResult();
			}
			reader.Close();
			_connect.Close();

			return result;

		}

		public static int GetCountItem(SqlConnection _connect, string  sql)
		{
			int result = 0;

			_connect.Open();
			SqlCommand cmd = new SqlCommand(sql, _connect);

			SqlDataReader reader = cmd.ExecuteReader();

			while (reader.HasRows)
			{
				while (reader.Read())
				{
					result = reader.GetInt32(0);
				}
				reader.NextResult();
			}
			reader.Close();
			_connect.Close();

			return result;

		}

		public static List<Comment> ReadCommentsProduct(SqlConnection _connect, string id)
		{
			List<Comment> list = new List<Comment>();
			string sql =
				"select Nick_name, Commentariy, date_add from Comment" +
				" left join ComVsProduct on ComVsProduct.id_comments = Comment.id_com" +
				" left join Users on Users.id_user = Comment.id_user where id_product = " + id;

			_connect.Open();
			SqlCommand cmd = new SqlCommand(sql, _connect);

			SqlDataReader reader = cmd.ExecuteReader();

			while (reader.HasRows)
			{
				while (reader.Read())
				{
					list.Add(new Comment(reader.GetString(0), reader.GetString(1), reader.GetDateTime(2)));
				}
				reader.NextResult();
			}
			reader.Close();
			_connect.Close();

			return list;
		}

		public static List<CommentAndProduct> ReadCommentsProduct(SqlConnection _connect)
		{
			List<CommentAndProduct> list = new List<CommentAndProduct>();
			string sql =
				"select Top 5 Commentariy, id_product, Maker, Model, Cabin, Year_creation, Comment.date_add from Comment" +
				" left join ComVsProduct on ComVsProduct.id_comments = Comment.id_com" +
				" left join Users on Users.id_user = Comment.id_user" + 
				" left join Product on Product.id = id_product" +
				" order by date_add desc";
 
			_connect.Open();
			SqlCommand cmd = new SqlCommand(sql, _connect);

			SqlDataReader reader = cmd.ExecuteReader();

			while (reader.HasRows)
			{
				while (reader.Read())
				{
					list.Add(new CommentAndProduct(reader.GetString(0), reader.GetString(2), reader.GetString(3), reader.GetString(4), Convert.ToString(reader.GetInt16(5)), Convert.ToString(reader.GetInt32(1))));
				}
				reader.NextResult();
			}
			reader.Close();
			_connect.Close();

			return list;
		}

		public static string[] ReadRolesInUser(SqlConnection _connect, int id_user)
		{
			_connect.Open();

			List<string> str = new List<string>();
			string[] roles = new string[] {};
			string sql = "select Roles.Name from UserRole " +
			             "left join Roles on id = id_role " +
			             "left join Users on Users.id_user = UserRole.id_user " +
			             "where Users.id_user = " + id_user;

			
			SqlCommand cmd = new SqlCommand(sql, _connect);

			SqlDataReader reader = cmd.ExecuteReader();

			while (reader.HasRows)
			{
				while (reader.Read())
				{
					str.Add(reader.GetString(0));
				}
				reader.NextResult();
			}

			reader.Close();
			_connect.Close();

			roles = str.ToArray();
			return roles;
		}

		public static string ReadRoleInUser(SqlConnection _connect, int id_user, string roleName)
		{
			_connect.Open();

			string roles = "";
			string sql = "select Roles.Name from UserRole " +
						 "left join Roles on id = id_role " +
						 "left join Users on Users.id_user = UserRole.id_user " +
						 "where Users.id_user = " + id_user + 
						 " And Roles.Name = '" + roleName + "'";

			SqlCommand cmd = new SqlCommand(sql, _connect);
			SqlDataReader reader = cmd.ExecuteReader();

			if (reader.HasRows)
			{
				while (reader.Read())
				{
					roles = reader.GetString(0);
				}
				reader.NextResult();
			}
			reader.Close();
			_connect.Close();


			return roles;
		}
	}
}
