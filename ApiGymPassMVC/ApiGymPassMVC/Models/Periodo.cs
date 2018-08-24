using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiGymPassMVC.Models
{
    public class Periodo
    {
        public int IdPeriodo { get; set; }

        public string NmDescricao { get; set; }

        public int IdBox { get; set; }

        public decimal VlrPeriodo { get; set; }
    }
}