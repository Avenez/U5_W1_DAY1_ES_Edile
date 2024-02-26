using Edile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Edile.Controllers
{
    public class DipendenteController : Controller
    {
        // GET: Dipendente

        List<Dipendente> Dipendenti = new List<Dipendente>();
        public ActionResult Index()
        {

             
            return View();
        }

        [HttpGet]
        public ActionResult Create() { return View(); }

        [HttpPost]
        public ActionResult Create(Dipendente D) 
        {
            Dipendenti.Add(D);

            foreach (var item in Dipendenti) {
            Response.Write(item.Nome + item.Cognome);
            }
            return View(); 
        }
    }
}