using Business.ConCrete;
using DataAccess.ConCrete;
using Entity.ConCrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OkulProjesi.Controllers
{

    public class LoginController : Controller
    {
        Context db = new Context();
        AdminManager adm = new AdminManager();
        StudentManager st = new StudentManager();
        TeacherManager tchr = new TeacherManager();

        [AllowAnonymous]
        [HttpGet]
        public ActionResult adminLogin()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult adminLogin(Admin p)
        {
            var sorgu = db.admin.Where(x => x.userName == p.userName && x.password == p.password).SingleOrDefault();
            if (sorgu != null)
            {
                FormsAuthentication.SetAuthCookie(sorgu.userName, false);
                Session["ID"] = sorgu.adminID;
                Session["kAdi"] = sorgu.userName.ToString();
                Session["kSifre"] = sorgu.password.ToString();
                Response.Cookies["ozel"]["yetki"] = sorgu.authority.ToString();
                return RedirectToAction("Index", "Admin");
            }
            ViewBag.hata = "Kullanıcı Adı veya Şifre Hatalı";
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult studentLogin()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult studentLogin(Student p)
        {
            var sorgu = db.student.Where(x => x.userName == p.userName && x.password == p.password).SingleOrDefault();
            if (sorgu != null)
            {
                FormsAuthentication.SetAuthCookie(sorgu.userName, false);
                Session["ID"] = sorgu.studentID;
                Session["kAdi"] = sorgu.userName.ToString();
                Session["kSifre"] = sorgu.password.ToString();
                Response.Cookies["ozel"]["yetki"] = sorgu.authority.ToString();
                return RedirectToAction("Index", "Student");
            }
            ViewBag.hata = "Kullanıcı Adı veya Şifre Hatalı";
            return View();
        }


        [AllowAnonymous]
        [HttpGet]
        public ActionResult teacherLogin()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult teacherLogin(Teacher p)
        {
            var sorgu = db.teacher.Where(x => x.userName == p.userName && x.password == p.password).SingleOrDefault();
            if (sorgu != null)
            {
                // Login işlemi yapan sayfalar için bu kod yazılmassa Sistem Kullanıcı Adı,Şifre doğru olsa bile girişe izin vermiyor.
                FormsAuthentication.SetAuthCookie(sorgu.userName, false); 
                Session["ID"] = sorgu.teacherID;
                Session["kAdi"] = sorgu.userName.ToString();
                Session["kSifre"] = sorgu.password.ToString();
                Response.Cookies["ozel"]["yetki"] = sorgu.authority.ToString();
                return RedirectToAction("Index", "Teacher");
            }
            ViewBag.hata = "Kullanıcı Adı veya Şifre Hatalı";
            return View();
        }

        [Authorize(Roles ="student")]
        [HttpGet]
        public ActionResult studentProfile(string p)
        {
            p = (string)Session["kAdi"];
            var sorgu = st.FindStudent(p);
            return View(sorgu);
        }

        [Authorize(Roles = "teacher")]
        [HttpGet]
        public ActionResult teacherProfile(string p)
        {
            p = (string)Session["kAdi"];
            var sorgu = tchr.FindTeacher(p);
            return View(sorgu);
        }

        [Authorize(Roles = "admin")]
        public ActionResult adminProfile(string p)
        {
            p = (string)Session["kAdi"];
            var sorgu = adm.FindAdmin(p);
            return View(sorgu);
        }


        public ActionResult singout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}