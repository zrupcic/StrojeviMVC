using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StrojeviMVC.Models
{
    public class Kvar
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public int StrojID { get; set; }
        public string Opis { get; set; }
        public int Prioritet { get; set; }
        public int Status { get; set; }
        public DateTime? VrijemePrijave { get; set; }

        public virtual Stroj Stroj { get; set; }
    }
}