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
    [Authorize]
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

      

       
    

    }
}
