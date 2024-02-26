﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Edile.Models
{
    public class Dipendente
    {

        //public int ID { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }

        public string CF { get; set; }

        public bool Coniugato { get; set; }
        public int NumeroFigli { get; set; }

        public string Mansione { get; set; }

        public Dipendente() { }

        public Dipendente(string Nome, string Cognome, string CF, bool Coniugato, int NumeroFigli, string Mansione) 
        { 
        
            //this.ID = ID;
            this.Nome = Nome;
            this.Cognome = Cognome;
            this.CF = CF;
            this.Coniugato = Coniugato;
            this.NumeroFigli = NumeroFigli;
            this.Mansione = Mansione;

        
        } 


    }
}