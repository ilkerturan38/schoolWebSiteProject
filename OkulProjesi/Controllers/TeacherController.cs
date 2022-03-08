using Business.ConCrete;
using Entity.ConCrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OkulProjesi.Controllers
{
    public class TeacherController : Controller
    {
        TeacherManager tm = new TeacherManager();
        StudentManager std = new StudentManager();
        
        public ActionResult Index()
        {
            var deger = Session["kAdi"];
            var sorgu = tm.FindTeacher((string)deger);
            return View(sorgu);
        }

        public ActionResult LessonListPV()
        {
            var deger = Session["ID"];
            var sorgu = tm.GetTeacherByID((int)deger);
            return PartialView(sorgu);
        }

        
        public ActionResult lessonList()
        {
            var deger = Session["ID"];
            var sorgu = tm.GetTeacherByID((int)deger);
            return PartialView(sorgu);
        }


        public ActionResult studentList()
        {
            var deger = Session["ID"];
            var sorgu = tm.GetTeacherByID2((int)deger);
            return View(sorgu);
        }


        public ActionResult notesList()
        {
            var deger = Session["ID"];
            var sorgu = tm.GetTeacherByID3((int)deger);
            return PartialView(sorgu);
        }

        [HttpPost]
        public ActionResult teacherProfileUpdate(Teacher p, HttpPostedFileBase imageURL)
        {
            FileInfo file = new FileInfo(imageURL.FileName);
            int iFileSize = imageURL.ContentLength;
            try
            {
                if (iFileSize < (1024 * 1024 * 5))
                {
                    var dosyayoluKontrol = System.IO.Path.Combine(Server.MapPath("~/Uploads/teacherProfile/") + file);
                    imageURL.SaveAs(dosyayoluKontrol);
                    p.imageURL = "/Uploads/teacherProfile/" + file;
                    tm.Update(p);
                    return RedirectToAction("Index", "Teacher");
                } 
            }
            catch
            {
                return RedirectToAction("Index", "Admin");
            }

            return View();
        }

    }
}