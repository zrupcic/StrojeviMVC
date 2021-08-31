using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using Npgsql;
using StrojeviMVC.Models;

namespace StrojeviMVC.Controllers
{
    public class StrojController : Controller
    {
        private readonly string conStr = ConfigurationManager.ConnectionStrings["strojeviConnection"].ConnectionString;
        // GET: Stroj
        public ActionResult Index()
        {
            List<Stroj> StrojList = new List<Stroj>();
            using (IDbConnection db = new NpgsqlConnection(conStr))
            {

                StrojList = db.Query<Stroj>("Select * From Strojevi").ToList();
            }
            return View(StrojList);
        }

        // GET: Stroj/Details/5
        public ActionResult Details(int id)
        {
            Stroj stroj = new Stroj();
            using (IDbConnection db = new NpgsqlConnection(conStr))
            {
                stroj = db.Query<Stroj>("Select * From Strojevi WHERE ID =" + id, new { id }).SingleOrDefault();
            }
            return View(stroj);
        }

        // GET: Stroj/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Stroj/Create
        [HttpPost]
        public ActionResult Create(Stroj stroj)
        {
            try
            {
                using (IDbConnection db = new NpgsqlConnection(conStr))
                {
                    string sqlQuery = "Insert Into Strojevi (Naziv, Oznaka, DatumNabave) Values(@Naziv, @Oznaka, @DatumNabave)";

                    int rowsAffected = db.Execute(sqlQuery, stroj);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Stroj/Edit/5
        public ActionResult Edit(int id)
        {
            Stroj stroj = new Stroj();
            using (IDbConnection db = new NpgsqlConnection(conStr))
            {
                stroj = db.Query<Stroj>("Select * From Strojevi WHERE ID =" + id, new { id }).SingleOrDefault();
            }
            return View(stroj);
        }

        // POST: Stroj/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Stroj stroj)
        {
            try
            {
                using (IDbConnection db = new NpgsqlConnection(conStr))
                {
                    string sqlQuery = "UPDATE Strojevi set Naziv='" + stroj.Naziv +
                        "',Oznaka='" + stroj.Oznaka +
                        "',DatumNabave='" + stroj.DatumNabave +
                        "' WHERE ID=" + stroj.Id;

                    int rowsAffected = db.Execute(sqlQuery);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Stroj/Delete/5
        public ActionResult Delete(int id)
        {
            Stroj stroj = new Stroj();
            using (IDbConnection db = new NpgsqlConnection(conStr))
            {
                stroj = db.Query<Stroj>("Select * From Strojevi WHERE ID =" + id, new { id }).SingleOrDefault();
            }
            return View(stroj);
        }

        // POST: Stroj/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (IDbConnection db = new NpgsqlConnection(conStr))
                {
                    string sqlQuery = "Delete From Strojevi WHERE ID = " + id;

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
