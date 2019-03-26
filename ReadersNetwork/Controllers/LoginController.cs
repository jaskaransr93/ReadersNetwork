using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReadersNetwork.Models;
using ReadersNetwork.DAL;
using System.Data.Entity;

namespace ReadersNetwork.Controllers
{
    public class LoginController : Controller
    {
        ReadersContext dbContext = new ReadersContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User user)
        {
            
            if (!String.IsNullOrEmpty(user.Id) && !String.IsNullOrEmpty(user.Password))
            {
                var userfound = dbContext.Users.First(u => u.Id == user.Id && u.Password == user.Password);
                ViewBag.user = userfound;
                if (userfound != null)
                {
                    return RedirectToAction("Index", "Book");
                }
            }
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                
                user.UserAdded = new DateTime();
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}