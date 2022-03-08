using Business.ConCrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OkulProjesi.Controllers
{
    public class LessonController : Controller
    {
        LessonManager lm = new LessonManager();
        public ActionResult Index()
        {
            var sorgu = lm.getAll();
            return View(sorgu);
        }

    }
}