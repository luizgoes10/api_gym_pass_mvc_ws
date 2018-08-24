using System.Collections.Generic;

namespace ApiGymPassMVC.Models
{
    public class Estado
    {
        public int IdEstado { get; set; }

        public string NmEstado { get; set; }

        public int IdRegiao { get; set; }

        public List<Localizacao> Localizacao { get; set; }
    }
}