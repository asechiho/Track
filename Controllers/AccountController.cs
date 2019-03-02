using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Cars.Models;
using Cars.Classes;
using Microsoft.Ajax.Utilities;

namespace Cars.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
		SqlConnection connect = new SqlConnection("Data Source=(local); Initial Catalog=CARS; Integrated Security=SSPI;");

		public string CreateSignature(string text)
		{
			MD5 md5 = MD5.Create();
			byte[] messagebytes = Encoding.ASCII.GetBytes(text);
			byte[] lol = md5.ComputeHash(messagebytes);
			StringBuilder sOutput = new StringBuilder(lol.Length);
			for (int i = 0; i < lol.Length; i++)
			{
				sOutput.Append(lol[i].ToString("X2"));
			}

			return sOutput.ToString();
		}

        public ActionResult Login()
        {
            return View();
        }

		[HttpPost]
		public ActionResult Login(UserVIewLogin user, string returnUrl)
		{
			if (ModelState.IsValid)
			{
				if (ValidateUser(user.nickName, user.password))
				{
					FormsAuthentication.SetAuthCookie(user.nickName, user.remember);
					if (Url.IsLocalUrl(returnUrl))
					{
						return Redirect(returnUrl);
					}
					else
					{
						return Redirect("~/Home/Index");
					}
				}
				else
				{
					ModelState.AddModelError("", "Wrong password or login");
				}
			}
			return View(user);
		}

		public ActionResult Register()
		{
			User user = new User();
			return View(user);
		}

	    [HttpPost]
	    public ActionResult Register(User user, string returnUrl)
	    {
			string hash = CreateSignature(user.nickName+user.password);

		    string date = 
				"values('" + user.nickName + "','" + user.firstName + "','" + user.lastName + "','" + user.phone +
						  "','" + user.address + "','" + user.email + "','" + hash + "','" + user.image + "')";

		    string sql =
				"insert into Users(Nick_Name, First_Name, Last_Name, Phone, Address, Email, Passport,Image) " + date;
		    if (ModelState.IsValid)
		    {
			    if (ValidateLogin(user.nickName))
			    {
					FormsAuthentication.SetAuthCookie(user.nickName, user.remember);
					WriteSqlServer.UpdateDBonQuery(connect, sql);
					if (Url.IsLocalUrl(returnUrl))
					{
						return Redirect(returnUrl);
					}
					else
					{
						return RedirectToAction("Index", "Home");
					}
			    }
				else
				{
					ModelState.AddModelError("", "User with this Nick name already exists");
				}
		    }
		    return View(user);
	    }

	    public ActionResult LogOff()
	    {
			FormsAuthentication.SignOut();
			return RedirectToAction("Login", "Account");
	    }

	    public ActionResult User(string id)
	    {
		    UserViewEdit edit = ReadSqlServer.ReadUserV(connect, id);
		    edit.posts = 1;
		    return View(edit);
	    }

		[HttpPost]
		public ActionResult User(UserViewEdit user)
		{
			string sql = "update Users set Nick_name = '" + user.nickName + "', First_name = '" + user.firstName + "', Last_name = '" + user.lastName + "', Email = '" + user.email + "', Address = '" + user.address + "', Phone = '" + user.phone + "' where Nick_name = '" + user.nickName + "'";

			if (ModelState.IsValid)
			{
				WriteSqlServer.UpdateDBonQuery(connect, sql);
				FormsAuthentication.SetAuthCookie(user.nickName, false);
				return RedirectToAction("User", "Account", new {id = user.nickName});
			}
			else
			{
				UserViewEdit edit = ReadSqlServer.ReadUserV(connect, user.nickName);
				edit.posts = 2;
				return View(edit);
			}
		}

	    public bool ValidateLogin(string login)
	    {
			string sql = "Select * from Users where Nick_name = '" + login + "'";
			connect.Open();
			SqlCommand cmd = new SqlCommand(sql, connect);

		    SqlDataReader x = cmd.ExecuteReader();
		    if (x.HasRows)
			{
		                connect.Close();
			        return false;
	                }
		    else
			{
				connect.Close();
				return true;
		    }
	    }

	    public bool ValidateUser(string login, string password)
	    {
			string hash = CreateSignature(login + password);

			string sql = "use Cars Select * from Users where Nick_name = '" + login + "' And Passport = '" + hash + "'";
			connect.Open();
			SqlCommand cmd = new SqlCommand(sql, connect);

			SqlDataReader reader = cmd.ExecuteReader();

			if (reader.HasRows)
			{
				connect.Close();
				return true;
			}
			else
			{
				connect.Close();
				return false;
			}
	    }

		[HttpGet]
	    public JsonResult ValidPassword(string nickname, string password)
	    {
		    if (ValidateUser(nickname, password))
		    {
			    string sql =
				    "update Users set Passport = '" + CreateSignature(nickname + password) + "' where Nick_name = '" + nickname + "'";

				if (WriteSqlServer.UpdateDBonQuery(connect, sql))
			    {
				    FormsAuthentication.GetAuthCookie(nickname, false);
				    string message = "Ok";
				    return Json(message, JsonRequestBehavior.AllowGet);
			    }
			    else
			    {
					string message = "Fail";
					return Json(message, JsonRequestBehavior.AllowGet);
			    }
		    }
		    else
		    {
				string message = "FailValid";
				return Json(message, JsonRequestBehavior.AllowGet);
		    }
	    }
    }
}
