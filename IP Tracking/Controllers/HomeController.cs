using IP_Tracking.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using IP_Tracking.Models;

namespace IP_Tracking.Controllers
{
    public class HomeController : Controller
    {

        // GET: ProductController
        // In MVC all action methods are in get method, so we have to use [HttpGet].

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Login vm)
        {
            if (string.IsNullOrEmpty(vm.UserName) || string.IsNullOrEmpty(vm.Password))
                return View();
            else
            {
                string conString = ConfigurationManager.ConnectionStrings["loginConnectionstring"].ConnectionString;
                SqlConnection sqlconn = new SqlConnection(conString);
                string sqlquery = "select username,password from login where username=@username and password=@password";
                sqlconn.Open();
                SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
                sqlcomm.Parameters.AddWithValue("@username", vm.UserName);
                sqlcomm.Parameters.AddWithValue("@password", vm.Password);
                SqlDataReader sdr = sqlcomm.ExecuteReader();
                if (sdr.Read())
                {
                    return RedirectToAction("About");
                }
                else
                {
                    ViewData["Message"] = "Invalid Credential ! ";
                }
                sqlconn.Close();
            }
            return View();

        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}