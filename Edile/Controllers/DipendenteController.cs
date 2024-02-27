using Edile.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Edile.Controllers
{
    public class DipendenteController : Controller
    {
        // GET: Dipendente
        static string connectionString = ConfigurationManager.ConnectionStrings["connectionStringDb"].ToString();
        SqlConnection conn = new SqlConnection(connectionString);

        public ActionResult Index()
        {

            
            return View();
        }

        [HttpGet]
        public ActionResult Create() { return View(); }

        [HttpPost]
        public ActionResult Create(Dipendente D) 
        {
            try 
            { 
            conn.Open();
            SqlCommand cmd = new SqlCommand(connectionString, conn);
                cmd.CommandText = "INSERT INTO Dipendenti (Nome, Cognome, CF, Coniugato, NumeroFigli, Mansione) VALUES (@Nome, @Cognome, @CF, @Coniugato, @NumeroFigli, @Mansione)";
                cmd.Parameters.AddWithValue("Nome", D.Nome);
                cmd.Parameters.AddWithValue("Cognome", D.Cognome);
                cmd.Parameters.AddWithValue("CF", D.CF);
                cmd.Parameters.AddWithValue("Coniugato", D.Coniugato);
                cmd.Parameters.AddWithValue("NumeroFigli", D.NumeroFigli);
                cmd.Parameters.AddWithValue("Mansione", D.Mansione);
                
                cmd.ExecuteNonQuery();

                Response.Write("Inserimento avvenuto con Successo");
            }
            catch (Exception ex)
            {
             Response.Write(ex);    
            }
            finally
            {
                conn.Close();
            }



            ModelState.Clear();
            return View(); 
        }
    }
}