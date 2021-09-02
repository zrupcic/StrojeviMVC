using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StrojeviMVC.Models
{
    public class KvarVM
    {
        public List<Kvar> Kvarovi { get; set; }
        public SelectList Strojevi { get; set; }
        public string Naziv { get; set; }
    }
}