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
    
    public class StudentController : Controller
    {
        StudentManager st = new StudentManager();
        NotesManager nt = new NotesManager();
      
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LessonList()
        {
            var deger = Session["ID"];
            var sorgu = st.GetStudentByID((int)deger);
            return View(sorgu);
        }

        public ActionResult lessonListPV()
        {
            var deger = Session["ID"];
            var sorgu = st.GetStudentByID((int)deger);
            return PartialView(sorgu);
        }

        public ActionResult NotesList()
        {
            var deger = Session["ID"];
            var sorgu = st.GetStudentByID2((int)deger);
            return View(sorgu);
        }

        

        [HttpPost]
        public ActionResult studentProfileUpdate(Student p, HttpPostedFileBase imageURL)
        {
            FileInfo file = new FileInfo(imageURL.FileName);
            int iFileSize = imageURL.ContentLength;
            try
            {
                if (iFileSize < (1024 * 1024 * 5))
                {
                    var dosyayoluKontrol = System.IO.Path.Combine(Server.MapPath("~/Uploads/studentProfile/") + file);
                    imageURL.SaveAs(dosyayoluKontrol);
                    p.imageURL = "/Uploads/studentProfile/" + file;
                    st.Update(p);
                    return RedirectToAction("Index", "Student");
                }
            }
            catch
            {
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }

        [HttpGet]
        public ActionResult studentUpdate()
        {
            return View();
        }
    }
}