using CrudNewProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace CrudNewProject.Controllers
{
    
   
    public class HomeController : Controller
    {
        EmployeesEntities db = new EmployeesEntities();

        [Authorize(Roles = "Admin")]
        

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginModel loginModel)
        {
            using (var context = new EmployeesEntities())
            {
                var result = context.Employee.Where(x => x.FirstName == loginModel.UserName).Where(x => x.Password == loginModel.Password).FirstOrDefault();
                try
                {
                    var firstname = result.FirstName;

                    var password = result.Password;
                    FormsAuthentication.SetAuthCookie(loginModel.UserName, false);
                    
                }
                catch (Exception)
                {
                    ViewBag.MyResult = "Invalid Username or Password";
                    return View();

                }
                return RedirectToAction("Index","Employees");
            }
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

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}