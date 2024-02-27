using Edile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Edile.WievModels
{
    public class Pagamenti_Lista
    {
        public List<Dipendente> Dipendenti { get; set; }
        public List<RecordPagamento> Pagamenti { get; set; }
    }
} 