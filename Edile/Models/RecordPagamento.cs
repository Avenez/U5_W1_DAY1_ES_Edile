using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Edile.Models
{
    public class RecordPagamento
    {
        [HiddenInput]
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