using System.Collections.Generic;

namespace ApiGymPassMVC.Models
{
    public class Localizacao
    {
        public int IdLocalizacao { get; set; }

        public string NmLocalizacao { get; set; }

        public int IdEstado { get; set; }

        public List<Empresa> Empresa { get; set; }
    }
}