using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReadersNetwork.DAL;
using ReadersNetwork.Models;

namespace ReadersNetwork.Controllers
{
    public class BookController : Controller
    {
        ReadersContext dbContext = new ReadersContext();
        // GET: Book
        public ActionResult Index()
        {
            return View(dbContext.Books);
        }

        public ActionResult Details(int? id)
        {
            if (id != null)
            {
                Book book = dbContext.Books.First<Book>(b => b.Id == id);
                return View(book);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                book.BookAdded = DateTime.Now;
                dbContext.Books.Add(book);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}