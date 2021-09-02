using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StrojeviMVC.Models;

namespace StrojeviMVC.Controllers
{
    public class StrojDisplayController : Controller
    {
        // GET: StrojDisplay
        StrojContext sc = new StrojContext();
        public ActionResult Index()
        {
            Stroj s = new Stroj();
            s.StrojList = new SelectList(sc.GetStrojList(), "ID", "Naziv");
            return View(s);
        }
    }
}