using Business.ConCrete;
using DataAccess.ConCrete;
using Entity;
using Entity.ConCrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OkulProjesi.Controllers
{
    public class AdminController : Controller
    {
        AdminManager adm = new AdminManager();
        TeacherManager ogr = new TeacherManager();
        StudentManager org = new StudentManager();
        EpisodeManager eps = new EpisodeManager();
        LessonManager less = new LessonManager();
        NotesManager not = new NotesManager();

        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        public ActionResult adminList()
        {
            var sorgu = adm.adminList();
            return View(sorgu);
        }

        [HttpPost]
        public ActionResult adminProfileUpdate(Admin p, HttpPostedFileBase imageURL)
        {
            FileInfo file = new FileInfo(imageURL.FileName);
            int iFileSize = imageURL.ContentLength;
            try
            {
                if (iFileSize < (1024 * 1024 * 5))
                {
                    var dosyayoluKontrol = System.IO.Path.Combine(Server.MapPath("~/Uploads/adminProfile/") + file);
                    imageURL.SaveAs(dosyayoluKontrol);
                    p.imageURL = "/Uploads/adminProfile/" + file;
                    adm.Update(p);
                    return RedirectToAction("adminProfile", "Login");
                }
            }
            catch
            {
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }

        //-------------------------------------------------------------------------

        [Authorize(Roles = "admin")]
        public ActionResult teacherList()
        {
            var sorgu = adm.teacherList();
            return View(sorgu);
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult teacherInsert()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult teacherInsert(Teacher p, HttpPostedFileBase imageURL)
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
                    ogr.Add(p);
                    return RedirectToAction("teacherList", "Admin");
                }
            }
            catch
            {
                return RedirectToAction("Index", "Admin");
            }

            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult teacherUpdate(int id)
        {
            var sorgu = ogr.getByID(id);
            return View(sorgu);
        }

        
        [HttpPost]
        public ActionResult teacherUpdate(Teacher p,HttpPostedFileBase imageURL)
        {
            try
            {
                FileInfo file = new FileInfo(imageURL.FileName);
                int iFileSize = imageURL.ContentLength;
                if (iFileSize < (1024 * 1024 * 5))
                {
                    var dosyayoluKontrol = System.IO.Path.Combine(Server.MapPath("~/Uploads/teacherProfile/") + file);
                    imageURL.SaveAs(dosyayoluKontrol);
                    p.imageURL = "/Uploads/teacherProfile/" + file;
                    ogr.Update(p);
                    return RedirectToAction("teacherList", "Admin");
                }
            }
            catch
            {
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult teacherNotesUpdate(int id)
        {
            var sorgu = not.getByID(id);
            return View(sorgu);
        }

        [HttpPost]
        public ActionResult teacherNotesUpdate(Notes p)
        {
            try
            {
                not.Update(p);
                return RedirectToAction("notesList", "Teacher");
            }
            catch
            {
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }

        //-------------------------------------------------------------------------

        [Authorize(Roles = "admin")]
        public ActionResult studentList()
        {
            var sorgu = adm.studentList();
            return View(sorgu);
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult studentInsert()
        {
            Context c = new Context();
            List<SelectListItem> icerik = (from item in c.episode.ToList()
                                            select new SelectListItem
                                            {
                                                Text = item.episodeName,
                                                Value = item.episodeID.ToString()
                                            }).ToList();
            ViewBag.episodeID = icerik;
            return View();
        }

        [HttpPost]
        public ActionResult studentInsert(Student p, HttpPostedFileBase imageURL)
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
                    org.Add(p);
                    return RedirectToAction("studentList", "Admin");
                }
            }
            catch
            {
                return RedirectToAction("Index", "Admin");
            }

            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult studentUpdate(int id)
        {
            Context c = new Context();
            var sorgu = org.getByID(id);
            List<SelectListItem> icerik = (from item in c.episode.ToList()
                                           select new SelectListItem
                                           {
                                               Text = item.episodeName,
                                               Value = item.episodeID.ToString()
                                           }).ToList();
            ViewBag.episodeID = icerik;
            return View(sorgu);
        }

        [HttpPost]
        public ActionResult studentUpdate(Student p, HttpPostedFileBase imageURL)
        {
            try
            {
                FileInfo file = new FileInfo(imageURL.FileName);
                int iFileSize = imageURL.ContentLength;
                if (iFileSize < (1024 * 1024 * 5))
                {
                    var dosyayoluKontrol = System.IO.Path.Combine(Server.MapPath("~/Uploads/studentProfile/") + file);
                    imageURL.SaveAs(dosyayoluKontrol);
                    p.imageURL = "/Uploads/studentProfile/" + file;
                    org.Update(p);
                    return RedirectToAction("studentList", "Admin");
                }
            }
            catch
            {
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }


        //-------------------------------------------------------------------------

        [Authorize(Roles = "admin")]
        public ActionResult episodeList()
        {
            var sorgu = adm.episodeList();
            return View(sorgu);
        }


        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult episodeInsert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult episodeInsert(Episode p)
        {
            try
            {
                eps.Add(p);
                return RedirectToAction("episodeList", "Admin");
            }
            catch
            {
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult episodeUpdate(int id)
        {
            Context c = new Context();
            var sorgu = eps.getByID(id);
            return View(sorgu);
        }

        [HttpPost]
        public ActionResult episodeUpdate(Episode p)
        {
            try
            {
                eps.Update(p);
                return RedirectToAction("episodeList", "Admin");
            }
            catch
            {
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }

        public ActionResult episodeDelete(int id)
        {
            try
            {
                eps.Delete(id);
                return RedirectToAction("episodeList", "Admin");
            }
            catch
            {
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }

        //-------------------------------------------------------------------------

        [Authorize(Roles = "admin")]
        public ActionResult lessonList()
        {
            var sorgu = adm.lessonList();
            return View(sorgu);
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult lessonInsert()
        {
            Context c = new Context();
            List<SelectListItem> icerik = (from item in c.teacher.ToList()
                                           select new SelectListItem
                                           {
                                               Text = item.nameSurname,
                                               Value = item.teacherID.ToString()
                                           }).ToList();
            ViewBag.teacherID = icerik;
            return View();
        }

        [HttpPost]
        public ActionResult lessonInsert(Lesson p)
        {
            try
            {
                less.Add(p);
                return RedirectToAction("lessonList", "Admin");
            }
            catch
            {
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult lessonUpdate(int id)
        {
            Context c = new Context();
            var sorgu = less.getByID(id);
            List<SelectListItem> icerik = (from item in c.teacher.ToList()
                                           select new SelectListItem
                                           {
                                               Text = item.nameSurname,
                                               Value = item.teacherID.ToString()
                                           }).ToList();
            ViewBag.teacherID = icerik;
            return View(sorgu);
        }

        [HttpPost]
        public ActionResult lessonUpdate(Lesson p)
        {
            try
            {
                less.Update(p);
                return RedirectToAction("lessonList", "Admin");
            }
            catch
            {
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }



        public ActionResult lessonDelete(int id)
        {
            try
            {
                less.Delete(id);
                return RedirectToAction("lessonList", "Admin");
            }
            catch
            {
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }

        //-------------------------------------------------------------------------

        [Authorize(Roles = "admin")]
        public ActionResult notesList()
        {
            var sorgu = adm.notesList();
            return View(sorgu);
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult notesUpdate(int id)
        {
            var sorgu = not.getByID(id);
            return View(sorgu);
        }

        [HttpPost]
        public ActionResult notesUpdate(Notes p)
        {
            try
            {
                not.Update(p);
                return RedirectToAction("notesList", "Admin");
            }
            catch
            {
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }



    }
}