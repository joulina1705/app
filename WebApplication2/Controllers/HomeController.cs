using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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
        public ActionResult Login()
        {
           

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Users u)
        {
            //this action is for handling post(login)
            if (ModelState.IsValid)// this cheks validity
            {
                using (MyDatabaseEntities dc = new MyDatabaseEntities())
                {
                    
                    
                    var v = dc.Users.Where(a => a.Username.Equals(u.Username) && a.Password.Equals(u.Password)).FirstOrDefault();
                    if (v != null)
                    {
                        
                        Session["LogedUserID"] = v.UserId.ToString();
                        Session["LogedUserName"] = v.Username.ToString();
                        return RedirectToAction("AfterLoginTables");
                    }
                }
            }
           
            return View(u);
        }
        public ActionResult AfterLogin()
        {
            if (Session["LogedUserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }

            
        }
        public ActionResult AfterLoginTables()
        {
            if (Session["LogedUserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }


        }
    }
}