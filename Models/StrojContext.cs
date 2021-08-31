using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace StrojeviMVC.Models
{
    public class StrojContext
    {
        private static readonly string conStr = ConfigurationManager.ConnectionStrings["strojeviConnection"].ConnectionString;
        NpgsqlConnection con = new NpgsqlConnection(conStr);
        public IEnumerable<Stroj> GetStrojList()
        {
            string query = "SELECT ID,Naziv FROM Strojevi";
            var result = con.Query<Stroj>(query);
            return result;
        }
    }
}