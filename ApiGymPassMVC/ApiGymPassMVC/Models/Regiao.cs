using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiGymPassMVC.Models
{
    public class Regiao
    {
        public int IdRegiao { get; set; }

        public string NmRegiao { get; set; }

        public List<Estado> Estado { get; set; }
    }
}