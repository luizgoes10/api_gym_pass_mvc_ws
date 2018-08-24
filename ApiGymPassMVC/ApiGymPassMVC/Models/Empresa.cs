using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiGymPassMVC.Models
{
    public class Empresa
    {
        public int IdEmpresa { get; set; }
        public string ImgLogo { get; set; }

        public string NmEmpresa { get; set; }

        public string AddrEndereco { get; set; }

        public string TelTelefone { get; set; }
        public bool BoolGostei { get; set; }

        public decimal VlrMinPreco { get; set; }

        public decimal VlrMaxPreco { get; set; }

        public string TxtSobre { get; set; }

        public string TxtCortesia { get; set; }

        public string TxtLocalizacao { get; set; }

        public int IdLocalizacao { get; set; }

        public List<Box> Box { get; set; }
    }
}