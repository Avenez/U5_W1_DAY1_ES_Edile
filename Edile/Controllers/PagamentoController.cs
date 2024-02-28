using Edile.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static System.Collections.Specialized.BitVector32;

namespace Edile.Controllers
{
    public class PagamentoController : Controller
    {

        static string connectionString = ConfigurationManager.ConnectionStrings["connectionStringDb"].ToString();
        SqlConnection conn = new SqlConnection(connectionString);
        public static List<Pagamento> pagamenti = new List<Pagamento>();

        
        // GET: Pagamento
        public ActionResult Index()
        {
            
            try
            {
                conn.Open();


                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM Pagamenti";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int IdPagamento = int.Parse(reader["IdPagamento"].ToString());
                    DateTime Data = DateTime.Parse(reader["Data"].ToString());
                    int Ammontare = int.Parse(reader["Ammontare"].ToString());
                    bool Acconto = reader["Acconto"].ToString() == "True" ? true : false;
                    int IdDipendente =int.Parse(reader["idDip"].ToString());

                    Pagamento pagamentoToAdd = new Pagamento(IdPagamento, Data, Ammontare, Acconto, IdDipendente);

                    pagamenti.Add(pagamentoToAdd);



                }


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


            return View(pagamenti);
        }

        [HttpGet]

        public ActionResult Create()
        {
            List<Dipendente> dipendenti = new List<Dipendente>();

            try
            {
                conn.Open();


                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM Dipendenti";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string IdDipendente = reader["IdDipendente"].ToString();
                    string Nome = reader["Nome"].ToString();
                    string Cognome = reader["Cognome"].ToString();
                    string CF = reader["CF"].ToString().Substring(0, 4);
                    bool Coniugato = reader["Coniugato"].ToString() == "True" ? true : false;
                    int NumFigli = int.Parse(reader["NumeroFigli"].ToString());
                    string Mansione = reader["Mansione"].ToString();

                    Dipendente Dipendente = new Dipendente(IdDipendente, Nome, Cognome, CF, Coniugato, NumFigli, Mansione);

                    dipendenti.Add(Dipendente);

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

            SelectList list = new SelectList(dipendenti, "ID", "fullId");
            ViewBag.DropdownList = list;
            return View();
        }

        [HttpPost]
        public ActionResult Create( Pagamento P) {


            try 
            {
             conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO Pagamenti (Data, Ammontare, Acconto, idDip) VALUES (@Data, @Ammontare, @Acconto, @idDip)";

                cmd.Parameters.AddWithValue("Data", P.Data);
                cmd.Parameters.AddWithValue("Ammontare", P.Ammontare);
                cmd.Parameters.AddWithValue("Acconto", P.Acconto);
                cmd.Parameters.AddWithValue("idDip", P.idDipendente);

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
            return RedirectToAction("Index", "Home");
        }
    }
}