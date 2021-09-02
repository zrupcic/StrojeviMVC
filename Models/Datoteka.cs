using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StrojeviMVC.Models
{
    public class Datoteka
    {
        public int Id { get; set; }
        public string Putanja { get; set; }
        public int KvarId { get; set; }
    }
}