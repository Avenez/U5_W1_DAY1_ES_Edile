using Antlr.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Edile.Models
{
    public class Pagamento
    {

        //public int Id { get; set; }
        public DateTime Data { get; set; }

        public int Ammontare { get; set; }
        public bool Acconto { get; set; }

        public int idDipendente { get; set; }


        public Pagamento() { }


    }
}