using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace StrojeviMVC.Models
{
    public class Stroj
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Oznaka { get; set; }
        public DateTime? DatumNabave { get; set; }

        public List<Kvar> Kvarovi { get; set; }
        public SelectList strojList { get; set; }
    }
}