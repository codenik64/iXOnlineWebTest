using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using iXOnline.Core.Interfaces;
using iXOnlineWeb.Core.FactoryLayer;
using iXOnlineWeb.Data.DataAccess;

namespace iXOnlineWeb.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        private iXOnlineWebEntities db = new iXOnlineWebEntities();
        private IGenericBook genericBook = BookFactory.CreateBooksLibrary();
    
        public ActionResult Index()
        {
            var bookList = genericBook.GetBooks();
            return View(bookList);
        }

       
        public ActionResult Details(int id)
        {
            var book = genericBook.FindById(id);
            return View(book);
        }



        public ActionResult Create()
        {
            return View();
        }
     
        public JsonResult PostBook( Book book)
        {
            if (ModelState.IsValid)
            {
                genericBook.InsertBook(book);
               
            }
            return Json(new { Result = "Success", Message = "Saved Book Successfully"}, JsonRequestBehavior.AllowGet);
        }

  
        public ActionResult Edit(int id)
        {
           var book = genericBook.FindById(id);
           return View(book);
        }

      
    
        public JsonResult UpdateBook(Book book)
        {
            if (ModelState.IsValid)
            {
                genericBook.UpdateBook(book);
            }
            return Json(new { Result = "Success", Message = "Updated Book Successfully" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            var book = genericBook.FindById(id);
            return View(book);
        }

   
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            genericBook.RemoveBook(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
