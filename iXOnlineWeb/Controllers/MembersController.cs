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
    public class MembersController : Controller
    {
      
        IMember MemberAccess = MemberFactory.CreateMemberLibrary();

     
        public ActionResult Index()
        {
            var MemberList = MemberAccess.GetAll();
            return View(MemberList);
        }

       
        public ActionResult Details(int id)
        {
            var member = MemberAccess.FindById(id);
            return View(member);
        }

      
        public ActionResult Create()
        {
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Members member)
        {
            if (ModelState.IsValid)
            {
                MemberAccess.Insert(member);
                return RedirectToAction("Index");
            }

            return View(member);
        }

    
        public ActionResult Edit(int id)
        {
            var member = MemberAccess.FindById(id);
            return View(member);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Members member)
        {
            if (ModelState.IsValid)
            {
                MemberAccess.UpdateMember(member);
                return RedirectToAction("Index");
            }
            return View(member);
        }

        public JsonResult UpdateMember(Members member)
        {
            if (ModelState.IsValid)
            {
                MemberAccess.UpdateMember(member);

            }
            return Json(new { Result = "Success", Message = "Saved Book Successfully" }, JsonRequestBehavior.AllowGet);
        }



        public ActionResult Delete(int id)
        {
            var member = MemberAccess.FindById(id);
            return View(member);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MemberAccess.RemoveMember(id);
            return RedirectToAction("Index");
        }

       
    }
}
