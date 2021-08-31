using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using Npgsql;
using StrojeviMVC.Models;

namespace StrojeviMVC.Controllers
{
    public class KvarController : Controller
    {
        private readonly string conStr = ConfigurationManager.ConnectionStrings["strojeviConnection"].ConnectionString;
        // GET: Kvar
        public ActionResult Index()
        {
            List<Kvar> KvarList = new List<Kvar>();
            using (IDbConnection db = new NpgsqlConnection(conStr))
            {
                KvarList = db.Query<Kvar>("Select * From Kvarovi where Status=1 ORDER BY Prioritet, VrijemePrijave").ToList();
            }
            return View(KvarList);
        }

        /*public ActionResult Index(bool samoNeotklonjeni)
        {
            List<Kvar> KvarList = new List<Kvar>();
            using (IDbConnection db = new NpgsqlConnection(conStr))
            {
                if (samoNeotklonjeni)
                    KvarList = db.Query<Kvar>("Select * From Kvarovi where Status=1 ORDER BY Prioritet, VrijemePrijave").ToList();
                else
                    KvarList = db.Query<Kvar>("Select * From Kvarovi").ToList();
            }
            return View(KvarList);
        }*/

        // GET: Kvar/Details/5
        public ActionResult Details(int id)
        {
            Kvar kvar = new Kvar();
            using (IDbConnection db = new NpgsqlConnection(conStr))
            {
                kvar = db.Query<Kvar>("Select * From Kvarovi WHERE ID =" + id, new { id }).SingleOrDefault();
            }
            return View(kvar);
        }

        // GET: Kvar/Create
        public ActionResult Create()
        {            
            return View();
        }

        // POST: Kvar/Create
        [HttpPost]
        public ActionResult Create(Kvar kvar)
        {
            try
            {
                using (IDbConnection db = new NpgsqlConnection(conStr))
                {
                    string sqlQuery = "Insert Into Kvarovi (Naziv, StrojID, Opis, Prioritet, Status, VrijemePrijave) Values(@Naziv, @StrojID, @Opis, @Prioritet, @Status, @VrijemePrijave)";

                    int rowsAffected = db.Execute(sqlQuery, kvar);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Kvar/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Kvar/Edit/5
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

        // GET: Kvar/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Kvar/Delete/5
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
