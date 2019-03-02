using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Cars.Models;

namespace Cars.Classes
{
	public static class WriteSqlServer
	{
		public static bool UpdateDBonQuery(SqlConnection _connect, string _sql)
		{
			int x = 0;
			_connect.Open();
			SqlCommand sql = new SqlCommand(_sql, _connect);

			x = sql.ExecuteNonQuery();

			_connect.Close();

			if (x > 0) return true;
			else return false;

		}

		public static int UpdateDBonQueryId(SqlConnection _connect, string sql)
		{
			sql+="set @id = SCOPE_IDENTITY();";
			int id;
			_connect.Open();

			SqlCommand cmd = new SqlCommand(sql, _connect);

			var pID = new SqlParameter();
			pID.ParameterName = "id";
			pID.Size = 7;
			pID.Direction = ParameterDirection.Output;

			cmd.Parameters.Add(pID);

			cmd.ExecuteNonQuery();

			id = Int32.Parse(pID.Value.ToString());

			_connect.Close();

			return id;
		}

		public static int AddCar(SqlConnection _connect, ProductInfo car)
		{
			string sql =
				"insert into Prodcut(Maker, Model, Year_creation, Price, " +
				"Date_add, Image, Engine, V_engine, Chassis, Cabin, Horse_power, Color,Type_car, " +
				"Power, Max_KM, Max_power_KM, Max_KM_revolution, Type_transmission, " +
				"Count_transmission, Type_fuel) values('" + car.maker + "','" + car.model + "','" +
				car.yearCreation + "','" + car.price + "',Convert(datetime," + car.day + "." + car.month + "." + car.year + ", 103)" +
				",'" + car.image + "','" + car.typeEngine + "','" + car.vEngine + "','" + car.chassis + "','" + car.typeCabin +
				"','" + car.horsePower + "','" + car.color + "','" + car.typeCars + "','" + car.power + "','" + car.maxKM +
				"','" + car.maxPowerKM + "','" + car.maxKMRevolution + "','" + car.typeTransmission + "','" + car.countTransmission +
				"','" + car.typeFuel + "'); set @id = SCOPE_IDENTITY();";

			int id;
			_connect.Open();

			SqlCommand cmd = new SqlCommand(sql, _connect);

			var pID = new SqlParameter();
			pID.ParameterName = "id";
			pID.Size = 7;
			pID.Direction = ParameterDirection.Output;

			cmd.Parameters.Add(pID);

			cmd.ExecuteNonQuery();

			id = Int32.Parse(pID.Value.ToString());

			_connect.Close();

			return id;
		}
	}
}
