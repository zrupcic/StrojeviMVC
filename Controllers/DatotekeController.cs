using Dapper;
using Npgsql;
using StrojeviMVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StrojeviMVC.Controllers
{
    public class DatotekeController : Controller
    {
        private readonly string conStr = ConfigurationManager.ConnectionStrings["strojeviConnection"].ConnectionString;
        // GET: Datoteke
        public ActionResult Index()
        {
            List<Datoteka> DatotekeList = new List<Datoteka>();
            using (IDbConnection db = new NpgsqlConnection(conStr))
            {

                DatotekeList = db.Query<Datoteka>("Select * From Datoteke").ToList();
            }
            return View(DatotekeList);
        }

        // GET: Datoteke/Details/5
        public ActionResult Details(int id)
        {
            Datoteka datoteke = new Datoteka();
            using (IDbConnection db = new NpgsqlConnection(conStr))
            {
                datoteke = db.Query<Datoteka>("Select * From Datoteke WHERE ID =" + id, new { id }).SingleOrDefault();
            }
            return View(datoteke);
        }

        // GET: Datoteke/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Datoteke/Create
        [HttpPost]
        public ActionResult Create(Datoteka datoteka)
        {
            try
            {
                using (IDbConnection db = new NpgsqlConnection(conStr))
                {
                    string sqlQuery = "Insert Into Datoteke (Putanja, KvarID) Values(@Putanja, @KvarID)";

                    int rowsAffected = db.Execute(sqlQuery, datoteka);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Datoteke/Edit/5
        public ActionResult Edit(int id)
        {
            Datoteka datoteka = new Datoteka();
            using (IDbConnection db = new NpgsqlConnection(conStr))
            {
                datoteka = db.Query<Datoteka>("Select * From Datoteke WHERE ID =" + id, new { id }).SingleOrDefault();
            }
            return View(datoteka);
        }

        // POST: Datoteke/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Datoteka datoteka)
        {
            try
            {
                using (IDbConnection db = new NpgsqlConnection(conStr))
                {
                    string sqlQuery = "UPDATE Datoteke set Putanja='" + datoteka.Putanja +
                        "',KvarID='" + datoteka.KvarId +
                        "' WHERE ID=" + datoteka.Id;

                    int rowsAffected = db.Execute(sqlQuery);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Datoteke/Delete/5
        public ActionResult Delete(int id)
        {
            Datoteka datoteka = new Datoteka();
            using (IDbConnection db = new NpgsqlConnection(conStr))
            {
                datoteka = db.Query<Datoteka>("Select * From Datoteke WHERE ID =" + id, new { id }).SingleOrDefault();
            }
            return View(datoteka);
        }

        // POST: Datoteke/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Datoteka datoteka)
        {
            try
            {
                using (IDbConnection db = new NpgsqlConnection(conStr))
                {
                    string sqlQuery = "Delete From Datoteke WHERE ID = " + id;

                    int rowsAffected = db.Execute(sqlQuery);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
