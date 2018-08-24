using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiGymPassMVC.Models
{
    public class Box
    {
        public int IdBox { get; set; }

        public string imgFoto { get; set; }

        public string NmBox { get; set; }

        public string TxtAmbiente { get; set; }

        public string TxtInfo { get; set; }

        public string TxtDescParceiro1Oferta { get; set; }

        public string TxtDescParceiro2Oferta { get; set; }

        public string LnkParceiro1 { get; set; }

        public string LnkParceiro2 { get; set; }

        public string NmInfoImportante { get; set; }

        public int IdEmpresa { get; set; }

        public List<Periodo> Periodo { get; set; }
    }
}