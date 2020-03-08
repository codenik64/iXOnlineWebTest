using iXOnline.Core.Interfaces;
using iXOnlineWeb.Core.FactoryLayer;
using iXOnlineWeb.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iXOnlineWeb.Controllers
{
    public class RatingController : Controller
     
    {
        IBookRating Rating = BookRatingFactory.CreateRatingLibrary();

        public ActionResult Index()
        {
            var list = Rating.GetAllRatings();
            return View(list);
        }

       
        public ActionResult Details(int id)
        {
            var FindById = Rating.FindById(id);
            return View(FindById);
        }

        // GET: Rating/Create
        public ActionResult Create()
        {
            return View();
        }

        
        public JsonResult InsertRatedBook(BookRating bookrate)
        {
            if (ModelState.IsValid)
            {
                Rating.InsertRating(bookrate);
            }
            return Json(new { Result = "Success", Message = "Updated Book Successfully" }, JsonRequestBehavior.AllowGet);
        }

        // GET: Rating/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Rating/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Rating/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Rating/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
