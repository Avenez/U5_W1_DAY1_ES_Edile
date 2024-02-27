using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace Edile.Models
{
    public class RecordPagamento
    {

        public string Id { get; set; }

        public string Data { get; set; }

        public string Ammontare { get; set; }
        public string Acconto { get; set; }

        public string IdDipendente { get; set; }

        public string Nome { get; set; }
        public string Cognome { get; set;}

        
        public RecordPagamento() { }

        public RecordPagamento( string Id, string Data, string Ammontare, string Acconto, string IdDipendente, string Nome, string Cognome ) 
        {
        this.Id = Id;
        this.Data = Data;
        this.Ammontare = Ammontare;
        this.Acconto = Acconto;
        this.IdDipendente = IdDipendente;
        this.Nome = Nome;
        this.Cognome = Cognome;

        }



    }
}