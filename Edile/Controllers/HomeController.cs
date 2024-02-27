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
    public class HomeController : Controller
    {

         static string connectionString = ConfigurationManager.ConnectionStrings["connectionStringDb"].ToString();
         SqlConnection conn = new SqlConnection(connectionString);


        public ActionResult Index()
        {
            List<RecordPagamento> pagamenti = new List<RecordPagamento>();
            try 
            {
                conn.Open();
                

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT IdPagamento, Data, Ammontare, Acconto, idDipendente, Nome , Cognome  FROM Pagamenti INNER JOIN Dipendenti ON Pagamenti.idDip = Dipendenti.idDipendente";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string IdPagamento = reader["IdPagamento"].ToString();
                    string Data = reader["Data"].ToString().Substring(0, 10);

                    string Ammontare = reader["Ammontare"].ToString();
                    string[] Cifra;

                    Cifra = Ammontare.Split(',');

                    string Totale = Cifra[0] + "." + Cifra[1].Substring(0, 2);

                    string Acconto = reader["Acconto"].ToString() == "True" ? "Si" : "No";
                    string IdDipendente = reader["idDipendente"].ToString();
                    string Nome = reader["Nome"].ToString();
                    string Cognome = reader["Cognome"].ToString();

                    RecordPagamento pagamentoToAdd = new RecordPagamento(IdPagamento, Data, Totale, Acconto, IdDipendente, Nome, Cognome);

                    pagamenti.Add(pagamentoToAdd);



                }
                reader.Close();

                
            }
            catch (Exception ex) 
            { 
                Response.Write("Errore");
                Response.Write(ex);
            }
            finally 
            {
            conn.Close();
            }


            /*
            if (Session["Pagamenti"] != null) {

                List<Pagamento> pagamenti = (List<Pagamento>)Session["Pagamenti"];
                return View(pagamenti);
                //System.Diagnostics.Debug.WriteLine(variabiledaverificare)
            }
            else
            {
                
                return View();
            }

            */


            return View(pagamenti);

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}