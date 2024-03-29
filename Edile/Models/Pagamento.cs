﻿using Antlr.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace Edile.Models
{
    public class Pagamento
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [DisplayName("Data pagamento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }

        public int Ammontare { get; set; }

        [Display (Name= "Selezionare se è un acconto")]
        public bool Acconto { get; set; }

        [Display(Name = "Selezionare un dipendente")]
        public int idDipendente { get; set; }


        public Pagamento() { }

        public Pagamento(int Id, DateTime Data, int Ammontare, bool Acconto, int idDipendente) 
        { 
            this.Id = Id;
            this.Data = Data;
            this.Ammontare = Ammontare;
            this.Acconto = Acconto;
            this.idDipendente = idDipendente;
        
        }


    }
}